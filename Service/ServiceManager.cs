﻿using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Service.Contracts;


namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        //public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, IDataShaper<EmployeeDto> dataShaper)
        //public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper,UserManager<User> userManager, IConfiguration configuration, IEmployeeLinks employeeLinks)
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IOptions<JwtConfiguration>  configuration, IEmployeeLinks employeeLinks)
        {
            _companyService = new Lazy<ICompanyService>(() =>
            new CompanyService(repositoryManager, logger, mapper));
            _employeeService = new Lazy<IEmployeeService>(() =>
            //new EmployeeService(repositoryManager, logger, mapper, dataShaper));
             new EmployeeService(repositoryManager, logger, mapper, employeeLinks));
            _authenticationService=new Lazy<IAuthenticationService>(()=>
            new AuthenticationService(logger, mapper, userManager, configuration));

        }

        public ICompanyService CompanyService => _companyService.Value;
        public IEmployeeService EmployeeService => _employeeService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
