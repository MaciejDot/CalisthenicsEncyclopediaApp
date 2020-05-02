using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.Repositories;
using WorkoutExecutionService.Domain.Command;

namespace WorkoutExecutionService.Domain.CommandHandler
{
    public class DeleteWorkoutExecutionCommandHandler : IRequestHandler<DeleteWorkoutExecutionCommand, Unit>
    {
        private readonly IWorkoutExecutionRepository _workoutExecutionRepository;
        public DeleteWorkoutExecutionCommandHandler(IWorkoutExecutionRepository workoutExecutionRepository)
        {
            _workoutExecutionRepository = workoutExecutionRepository;
        }
        public async Task<Unit> Handle(DeleteWorkoutExecutionCommand request, CancellationToken cancellationToken)
        {
            await _workoutExecutionRepository.DeleteWorkoutPlanAsync(request.Username, request.ExternalId);
            return new Unit();
        }
    }
}
