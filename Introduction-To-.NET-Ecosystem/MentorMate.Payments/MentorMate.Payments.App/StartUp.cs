using MentorMate.Payment.Business.Services;
using MentorMate.Payments.App;


var service = new ProductService();
var products = service.GetProducts();

PaymentsIO.PromptUser(products);

var productId = PaymentsIO.ReadInput(1, 5);
var payment = Creator.createPayment(productId, products);
var providerNumber = PaymentsIO.ReadPaymentProvider();

var paymentProvider = Creator.createProvider(providerNumber);
paymentProvider.ProcessPayment(payment);


