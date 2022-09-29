namespace CleanCode.SwitchStatements
{
	public class PayAsYouGoCustomer :Customer
	{
        public override MonthlyStatement GenerateStatement(MonthlyUsage usage)
        {
			var statement = new MonthlyStatement
			{
				CallCost = 0.12f * usage.CallMinutes,
				SmsCost = 0.12f * usage.SmsCount
			};

			statement.TotalCost = statement.CallCost + statement.SmsCost;

            return statement;
        }
    }
}