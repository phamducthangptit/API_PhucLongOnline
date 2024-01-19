using API1.VnPay.ViewModels;

namespace API1.VnPay.Services
{
    public interface IVnPayServices
    {
        string CreatePaymentUrl(HttpContext context, VnPaymentRequestModel model);
        VnPaymentResponseModel PaymentExcute(IQueryCollection collection);


    }
}
