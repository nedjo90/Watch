using Microsoft.AspNetCore.Http;
using Shared.RequestFeatures;

namespace Entities.LinkModels;

public record ProfessionalStatusLinkParameters(
    ProfessionalStatusParameters ProfessionalStatusParameters,
    HttpContext HttpContext);