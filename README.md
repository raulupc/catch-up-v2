INSTALL

swashbuckle.aspnetcore 9.0.6 ,

Microsoft.EntityFrameworkCore 9.0.10(blue) ,

Microsoft.EntityFrameworkCore.Tools 9.0.10 ,

MySql.EntityFrameworkCore 9.0.9


structure: 

´´´
pc2u202319415.API/
├─ src/
│  ├─ Subscriptions/                      <- Bounded Context: subscriptions
│  │  ├─ Application/
│  │  │  └─ Internal/
│  │  │     └─ CommandServices/
│  │  │        ├─ CreatePlanCommand.cs
│  │  │        └─ CreatePlanCommandHandler.cs
│  │  ├─ Domain/
│  │  │  ├─ Model/
│  │  │  │  ├─ Aggregates/
│  │  │  │  │  ├─ Plan.cs
│  │  │  │  │  └─ PlanAudit.cs
│  │  │  │  ├─ Commands/
│  │  │  │  │  └─ CreatePlanCommand.cs  (domain-level, optional)
│  │  │  │  ├─ Enumerations/
│  │  │  │  │  └─ EMonetizationStrategy.cs
│  │  │  │  └─ ValueObjects/
│  │  │  │     └─ (si aplica)
│  │  │  ├─ Repositories/
│  │  │  │  └─ IPlanRepository.cs
│  │  │  └─ Services/
│  │  │     └─ IPlanDomainService.cs   <-- para reglas que requieren repo (ej: unicidad, default)
│  │  ├─ Infrastructure/
│  │  │  └─ Persistence/
│  │  │     └─ EFC/
│  │  │        └─ Repositories/
│  │  │           └─ PlanRepository.cs
│  │  └─ Interfaces/
│  │     └─ REST/
│  │        ├─ Resources/
│  │        │  ├─ CreatePlanResource.cs
│  │        │  └─ PlanResource.cs
│  │        ├─ Transform/
│  │        │  ├─ CreatePlanAssembler.cs
│  │        │  └─ PlanAssembler.cs
│  │        └─ PlanController.cs
│  └─ Shared/                              <- Bounded Context: shared (utilidades)
│     ├─ Domain/
│     │  ├─ Model/
│     │  │  └─ AuditableEntity.cs
│     │  └─ Repositories/
│     │     ├─ IBaseRepository.cs
│     │     └─ IUnitOfWork.cs
│     └─ Infrastructure/
│        └─ Persistence/
│           └─ EFC/
│              ├─ AppDbContext.cs
│              ├─ Configuration/
│              │  └─ ModelBuilderExtensions.cs
│              └─ Repositories/
│                 ├─ BaseRepository.cs
│                 └─ UnitOfWork.cs
├─ appsettings.json
└─ Program.cs
´´´


upc-pre202502-1ASI0730-7414-pc2-u202319415.zip
