namespace SpecflowParallel.Steps;

[Parallelizable(ParallelScope.All)]

public class StepsBase
{
  protected ScenarioContext _scenarioContext;
  protected FeatureContext _featureContext;
  
  protected IPage Page { get; set; }
}