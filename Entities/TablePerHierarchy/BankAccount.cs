namespace EFInheritanceTypes.Entities
{
    public class BankAccount : BillingDetail
    {
        public string BankName { get; set; }
        public string Swift { get; set; }
    }
}