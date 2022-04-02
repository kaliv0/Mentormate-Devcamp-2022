using Observer.Models;

var bank = new Bank();
var firstCustomer = new RichCustomer("Peter Peterson");
var secondCustomer = new PoorCustomer("Foo Bar");

bank.Subscribe(firstCustomer);
bank.Subscribe(secondCustomer);

var thirdCustomer = new PoorCustomer("Robinson Crusoe");
bank.Subscribe(thirdCustomer);

bank.ChangeTaxes(0.2M);

bank.Unsubscribe(thirdCustomer);
bank.ChangeTaxes(0.5M);




