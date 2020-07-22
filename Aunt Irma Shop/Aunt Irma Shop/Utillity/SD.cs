using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aunt_Irma_Shop.Utillity
{
    public static class SD
    {
        public const string DefaultImage = "default_img.png";

        public const string OrderPlaced = "OrderPlaced.png";
        public const string ReadyForDispatch = "ReadyForDispatch.png";
        public const string OrderDispatched = "OrderDispatched.png";
        public const string Completed = "Completed.png";


        public const string ManagerUser = "Manager";
        public const string AssistantUser = "Assistant";
        public const string CustomerEndUser = "Customer";

        public const string StatusSubmitted = "Submitted";
        public const string StatusInProcess = "ReadyForDispatch";
        public const string StatusDispatched = "OrderDispatched";
        public const string StatusCompleted = "Completed";
        public const string StatusCancelled = "Cancelled";

        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusRejected = "Rejected";
    }
}
