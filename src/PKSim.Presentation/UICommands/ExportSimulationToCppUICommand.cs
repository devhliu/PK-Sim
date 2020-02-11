﻿using OSPSuite.Core.Extensions;
using OSPSuite.Core.Services;
using OSPSuite.Presentation.UICommands;
using PKSim.Core.Model;
using PKSim.Core.Services;

namespace PKSim.Presentation.UICommands
{
   public class ExportSimulationToCppUICommand : ActiveObjectUICommand<Simulation>
   {
      private readonly ISimulationExportTask _simulationExportTask;

      public ExportSimulationToCppUICommand(ISimulationExportTask simulationExportTask, IActiveSubjectRetriever activeSubjectRetriever) : base(activeSubjectRetriever)
      {
         _simulationExportTask = simulationExportTask;
      }

      protected override async void PerformExecute()
      {
         await _simulationExportTask.SecureAwait(x => x.ExportSimulationToCppAsync(Subject));
      }
   }
}