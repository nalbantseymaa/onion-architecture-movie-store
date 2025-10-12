using FluentValidation;
using MediatR;

namespace MovieApi.Application.Behaviors;

//her handlerda tekrar tekrar validation kodu yazmamak için
/// <summary>
/// MediatR Pipeline Behavior: Her Request çalıştırılmadan ÖNCE validation yapar.
/// Behavior = MediatR'ın request-response akışına araya giren "middleware" mantığı.
/// </summary>
/// <typeparam name="TRequest">Gelen istek tipi (örn: CreateMovieCommand)</typeparam>
/// <typeparam name="TResponse">Dönen cevap tipi (örn: CreateMovieResponse)</typeparam>
/// mediatR'ın interface : Request → Handler arasına girer
public class FluentValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    /// <summary>
    /// Bu Request için tanımlı TÜM validator'ları tutar.
    /// Dependency Injection otomatik olarak bulur ve enjekte eder.
    /// Örnek: CreateMovieCommand için CreateMovieCommandValidator
    /// </summary>
    private readonly IEnumerable<IValidator<TRequest>> validators;

    /// <summary>
    /// Constructor: DI Container otomatik olarak ilgili validator'ları bulup gönderir.
    /// Eğer CreateMovieCommand için validator yoksa, liste boş gelir 
    /// </summary>
    public FluentValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        this.validators = validators;
    }

    /// <summary>
    /// MediatR her Request'i Handler'a göndermeden ÖNCE bu metodu çalıştırır.
    /// </summary>
    /// <param name="request">Gelen Request (örn: CreateMovieCommand nesnesi)</param>
    /// <param name="next">Sonraki adım (Handler'ı çalıştır)</param>
    /// <param name="cancellationToken">İptal token'ı</param>
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        // ADIM 1: ValidationContext oluştur
        // Bu context, validator'lara "neyi" validate edeceğini söyler
        var context = new ValidationContext<TRequest>(request);

        // ADIM 2: TÜM validator'ları çalıştır ve hataları topla
        var failures = validators
            .Select(v => v.Validate(context))           // Her validator'ı çalıştır
            .SelectMany(result => result.Errors)        // Tüm hataları düzleştir (flatten)
            .Where(f => f != null)                      // Null hataları filtrele
            .ToList();                                  // Listeye çevir

        // ADIM 3: Hata var mı kontrol et
        // Any() = "Liste boş mu değil mi?" kontrolü
        if (failures.Any())
        {
            // Hata varsa: Exception fırlat, Handler çalışmaz!
            throw new ValidationException("Validation failed", failures);
        }

        // ADIM 4: Hata yoksa: Handler'ı çalıştır ve sonucu döndür
        return await next();
    }
}