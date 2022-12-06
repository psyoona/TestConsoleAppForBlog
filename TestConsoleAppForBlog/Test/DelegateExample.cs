namespace TestConsoleAppForBlog.Test
{
	using System;

	class DelegateExample
	{
		public DelegateExample()
		{
			this.accountTransfer = Withdraw;
			this.accountTransfer += Deposit;
			this.accountTransfer += MessageToClient1;
			this.accountTransfer += MessageToClient2;

			this.MoneyClient1 = 10000;
			this.MoneyClient2 = 20000;

			this.accountTransfer(100);
		}

		public int MoneyClient1 { get; set; }
		public int MoneyClient2 { get; set; }

		public delegate void AccountTransfer(int money);

		public AccountTransfer accountTransfer;

		public void Withdraw(int money)
		{
			this.MoneyClient1 -= money;
		}

		public void Deposit(int money)
		{
			this.MoneyClient2 += money;
		}

		public void MessageToClient1(int money)
		{
			Console.WriteLine($"{money}원이 출금되어 현재 {this.MoneyClient1}원입니다.");
		}

		public void MessageToClient2(int money)
		{
			Console.WriteLine($"{money}원이 입금되어 현재 {this.MoneyClient2}원입니다.");
		}
	}
}
