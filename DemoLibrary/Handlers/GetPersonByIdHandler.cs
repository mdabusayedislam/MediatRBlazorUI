using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoLibrary.Handlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonModel>
    {
        private readonly IMediator mediator;

        public GetPersonByIdHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var results= await mediator.Send(request:new GetPersonListQuery());
            var output= results.FirstOrDefault(x=>x.Id==request.id);
            return output;
        }
    }
}
