using Microsoft.AspNetCore.Http;
using Shared.RequestFeatures;

namespace Entities.LinkModels;

public record TrainingLinkParameters(TrainingParameters TrainingParameters, HttpContext Context);