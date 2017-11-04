using System;

public class WalletModel
{

    public string ID { get; set; }
    public decimal balance { get; set; }
    public bool status { get; set; }
    public int userId { get; set; }

	public WalletModel(string ID,decimal balance, bool status, int userId)
	{
        this.ID = ID;
        this.balance = balance;
        this.status = status;
        this.userId = userId;
	}

}
