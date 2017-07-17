using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static AdacoAPI.AdacoAPIForm;
//using static AdacoAPI.Data;
using static AdacoAPI.DataStructs;
using static AdacoAPI.MainAuth;

namespace AdacoAPI
{
    public class DataValidator
    {
        private static DataStructs.RequestData _currentRequest;
        private static DataStructs.FormData _onFormData;
        private string _validationErrorList;
        public DataValidator()
        {
            Subscribe(true);
        }

        private void Subscribe(bool action)
        {
            if (action)
            {
                EventDispatcher.Instance.DataMessage += MessageHandler;
            }
            else
            {
                if (EventDispatcher.Instance != null) EventDispatcher.Instance.DataMessage -= MessageHandler;
            }
        }

        private void MessageHandler(object sender, string message)
        {
            switch (message)
            {
                case "Start validation":
                    StartValidation();
                    break;
            }
        }

        private void StartValidation()
        {
            _onFormData = Data.OnFormData;

            if ((_onFormData.Request == "fail") & (!ValidationItself()))
            {
                _validationErrorList = "many errors";
                EventDispatcher.Instance.RaiseMainMessage("Validation Errors");  // TODO: should pass _validationErrorList to the form
            }
            else
            {
                CollectRequestData();
                // Also here we send request media to parser IF NEEDED
                // if it's parsed successfully, it's put in 
            }
        }

        private bool ValidationItself()
        {
            // TODO: implement _onFormData validation
            return true;
        }

        private static async void CollectRequestData()
        {
            var thisMethod = Data.Methods.MethodStructByName(_onFormData.MethodName);
            var resource = thisMethod.Resource.Replace("{", string.Empty).Replace("}", string.Empty);

            _currentRequest = new DataStructs.RequestData()
            {
                Method = thisMethod.Type,
                Uri = new Uri(_onFormData.Endpoint + _onFormData.Parameters.Keys.Aggregate(resource, (current, inx) => current.Replace(inx, _onFormData.Parameters[inx]))),
                Headers = _onFormData.AdacoHeaders
            }; //NO MEDIA HERE
            


            Data.CurrentRequest = _currentRequest;
            EventDispatcher.Instance.RaiseMainMessage("Request Collected");
            Task<string> task = RequestSender.SendRequest(Data.CurrentRequest); // TODO: return headers on UI
            string result = await task;

            //EventDispatcher.Instance.RaiseFormMessage(result);
        }
    }
}
/*

Feature: Transmit
    Currently contains test-cases for US25718: Applying Delivery Days & Cut Off Times When Manually Transmitting POs

Background: Create a Product
    And New Vendor exists
    And Order transmission<VendorInterface> set up correctly

@Property @CP @ignore
Scenario Outline: Order Transmission with Positive Delivery Day validation only

    Given When order is scheduled for a non delivery day is <DeliveryDayOption>

        And When order is sent after cut off time is 'No action'

        And This Vendor has
		| DeliveryDays         |
		| <VendorDeliveryDays> |

        And I create a Purchase Order with values
        | VendorNumber | ShipTo | BillTo | DeliveryDate   | OutletName |
        | $Vendor      | any    | any    | <DeliveryDate> | any        |

        And Product is added
        And I Save the Purchase Order
    When Purchase Center is opened
        And Transmit Order

    Then Order transmitted successfully
# For VendorDeliveryDays current day of the week should be known, 0 means no days are chosen
Examples: 
| DeliveryDayOption | VendorDeliveryDays     | DeliveryDate |
| No action         | wTomorrow+1            | $tomorrow    |
| Warning           | 0                      | $tomorrow    |
| Block             | 0                      | $tomorrow    |
| Warning           | wTomorrow, wTomorrow+1 | $tomorrow    |
| Block             | wTomorrow, wTomorrow+1 | $tomorrow    |

@Property @CP @ignore
Scenario Outline: Order Transmission with Positive Cut Off Time validation only
    Given When order is scheduled for a non delivery day is 'No action'

        And When order is sent after cut off time is <CutOffTimeOption>

        And This Vendor has
		| CutOffTime         |
		| <VendorCutOffTime> |

        And I create a Purchase Order with values
        | VendorNumber | ShipTo | BillTo | DeliveryDate   | OutletName |
        | $Vendor      | any    | any    | <DeliveryDate> | any        |

        And Product is added
        And I Save the Purchase Order
    When Purchase Center is opened
        And Transmit Order

    Then Order transmitted successfully
# For VendorCutOffTime current time is used with + or - 2 hours
Examples: 
| CutOffTimeOption | VendorCutOffTime | DeliveryDate |
| No action        | current+2hours   | $tomorrow    |
| Warning          | current-2hours   | $tomorrow    |
| Block            | current-2hours   | $tomorrow    |
| Warning          | current+2hours   | $tomorrow+1  |
| Block            | current+2hours   | $tomorrow+1  |
| Warning          | NULL             | $tomorrow    |
| Block            | NULL             | $tomorrow    |

@Property @CP @ignore
Scenario Outline: Order Transmission Blocked on either Delivery Day or Cut Off Time
    Given When order is scheduled for a non delivery day is <DeliveryDayOption>

        And When order is sent after cut off time is <CutOffTimeOption>

        And This Vendor has
		| DeliveryDays | CutOffTime     |
		| wTomorrow+1  | current+2hours |

        And I create a Purchase Order with values
        | VendorNumber | ShipTo | BillTo | DeliveryDate | OutletName |
        | $Vendor      | any    | any    | $tomorrow    | any        |

        And Product is added
        And I Save the Purchase Order
    When Purchase Center is opened
        And Transmit Order

    Then Alert with title '{title}' and message that starts with<Message> and contains Purchase order values should be shown
        And Dismiss the alert
        And Order is not transmitted
Examples: 
| DeliveryDayOption | CutOffTimeOption | Message                                                                                    |
| Block             | No action        | The following orders were not sent due to incorrect delivery days                          |
| No action         | Block            | The following orders were not sent due to being sent after the vendor's order cut off time |

@Property @CP @ignore
Scenario Outline: Order Transmission Warning YES on either Delivery Day or Cut Off Time

    Given When order is scheduled for a non delivery day is <DeliveryDayOption>

        And When order is sent after cut off time is <CutOffTimeOption>

        And This Vendor has
		| DeliveryDays | CutOffTime     |
		| wTomorrow+1  | current+2hours |

        And I create a Purchase Order with values
        | VendorNumber | ShipTo | BillTo | DeliveryDate | OutletName |
        | $Vendor      | any    | any    | $tomorrow    | any        |

        And Product is added
        And I Save the Purchase Order
    When Purchase Center is opened
        And Transmit Order

    Then Alert with title '{title}' and message that starts with<Message> and contains Purchase order values should be shown
        And Accept alert

        And Order transmitted successfully
Examples: 
| DeliveryDayOption | CutOffTimeOption | Message                                                                        |
| Warning           | No action        | This order is scheduled for delivery on                                        |
| No action         | Warning          | You are attempting to send this order after the vendor's cut off time which is |

@Property @CP @ignore
Scenario Outline: Order Transmission Warning NO on either Delivery Day or Cut Off Time

    Given When order is scheduled for a non delivery day is <DeliveryDayOption>

        And When order is sent after cut off time is <CutOffTimeOption>

        And This Vendor has
		| DeliveryDays | CutOffTime     |
		| wTomorrow+1  | current+2hours |

        And I create a Purchase Order with values
        | VendorNumber | ShipTo | BillTo | DeliveryDate | OutletName |
        | $Vendor      | any    | any    | $tomorrow    | any        |

        And Product is added
        And I Save the Purchase Order
    When Purchase Center is opened
        And Transmit Order

    Then Alert with title '{title}' and message that starts with<Message> and contains Purchase order values should be shown
        And Dismiss the alert
        And Order is not transmitted
Examples: 
| DeliveryDayOption | CutOffTimeOption | Message                                                                        |
| Warning           | No action        | This order is scheduled for delivery on                                        |
| No action         | Warning          | You are attempting to send this order after the vendor's cut off time which is |

@Property @CP @ignore
Scenario: Order Transmission Warning YES on Delivery Day & Warning NO on Cut Off Time

    Given When order is scheduled for a non delivery day is 'Warning'

        And When order is sent after cut off time is 'Warning'

        And This Vendor has
		| DeliveryDays | CutOffTime     |
		| wTomorrow+1  | current+2hours |

        And I create a Purchase Order with values
        | VendorNumber | ShipTo | BillTo | DeliveryDate | OutletName |
        | $Vendor      | any    | any    | $tomorrow    | any        |

        And Product is added
        And I Save the Purchase Order
    When Purchase Center is opened
        And Transmit Order

    Then Alert with title '{title}' and message that starts with 'This order is scheduled for delivery on' and contains Purchase order values should be shown

        And Accept alert
        And Alert with title '{title}' and message that starts with 'You are attempting to send this order after the vendor's cut off time which is' and contains Purchase order values should be shown

        And Dismiss the alert

        And Order is not transmitted

@Property @CP @ignore
Scenario: Order Transmission Warning YES on Delivery Day & Warning YES on Cut Off Time

    Given When order is scheduled for a non delivery day is 'Warning'

        And When order is sent after cut off time is 'Warning'

        And This Vendor has
		| DeliveryDays | CutOffTime     |
		| wTomorrow+1  | current+2hours |

        And I create a Purchase Order with values
        | VendorNumber | ShipTo | BillTo | DeliveryDate | OutletName |
        | $Vendor      | any    | any    | $tomorrow    | any        |

        And Product is added
        And I Save the Purchase Order
    When Purchase Center is opened
        And Transmit Order

    Then Alert with title '{title}' and message that starts with 'This order is scheduled for delivery on' and contains Purchase order values should be shown

        And Accept alert
        And Alert with title '{title}' and message that starts with 'You are attempting to send this order after the vendor's cut off time which is' and contains Purchase order values should be shown

        And Accept alert
        And Order transmitted successfully

@Property @CP @ignore
Scenario: Order Transmission Warning YES on Delivery Day & Blocked on Cut Off Time
    Given When order is scheduled for a non delivery day is 'Warning'

        And When order is sent after cut off time is 'Block'

        And This Vendor has
		| DeliveryDays | CutOffTime     |
		| wTomorrow+1  | current+2hours |

        And I create a Purchase Order with values
        | VendorNumber | ShipTo | BillTo | DeliveryDate | OutletName |
        | $Vendor      | any    | any    | $tomorrow    | any        |

        And Product is added
        And I Save the Purchase Order
    When Purchase Center is opened
        And Transmit Order

    Then Alert with title '{title}' and message that starts with 'This order is scheduled for delivery on' and contains Purchase order values should be shown

        And Accept alert
        And Alert with title '{title}' and message that starts with 'The following orders were not sent due to being sent after the vendor's order cut off time' and contains Purchase order values should be shown

        And Dismiss the alert

        And Order is not transmitted


    */