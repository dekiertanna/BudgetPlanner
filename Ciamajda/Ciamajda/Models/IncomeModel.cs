using System;

public class IncomeModel
{
    private int ID { get; set; }
    private decimal expense { get; set; }
    private string place { get; set; }
    private DateTime date { get; set; }
    private bool isCyclical { get; set; }
    private int daysCycle { get; set; }
    private string currency { get; set; }
    private int categoryID { get; set; }
    private int accountID { get; set; }

    public IncomeModel(int ID, decimal expense, string place, DateTime date, bool isCyclical, int daysCycle, string currency, int categoryID, int accountID)
    {
        this.ID = ID;
        this.expense = expense;
        this.place = place;
        this.date = date;
        this.isCyclical = isCyclical;
        this.currency = currency;
        this.categoryID = categoryID;
        this.accountID = accountID;
    }
}
