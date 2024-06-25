using Microsoft.AspNetCore.Http;
using Shared.RequestFeatures;

namespace Entities.LinkModels;

public record TrainingTypeLinkParameters(TrainingTypeParameters TrainingTypeParameters, HttpContext Context);