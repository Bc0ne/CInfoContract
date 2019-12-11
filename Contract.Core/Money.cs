namespace Contract.Core
{
    public class Money
    {
        public decimal? Value { get; set; }
        public Currency? Currency { get; set; }

        public static Money New(decimal? value, Currency? currency)
        {
            return new Money
            {
                Value = value,
                Currency = currency
            };
        }
    }
}
