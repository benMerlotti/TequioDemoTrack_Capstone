using AutoMapper;
using TequioDemoTrack.Models;
using TequioDemoTrack.Models.DTOs;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {

        CreateMap<UserProfile, UserProfileDTO>();
        CreateMap<UserProfileDTO, UserProfile>();
        CreateMap<Customer, CustomerDTO>();
        CreateMap<CustomerDTO, Customer>();
        CreateMap<Customer, CreateCustomerDTO>();
        CreateMap<CreateCustomerDTO, Customer>();
        CreateMap<Employee, EmployeeDTO>();
        CreateMap<EmployeeDTO, Employee>();
        CreateMap<Employee, CreateEmployeeDTO>();
        CreateMap<CreateEmployeeDTO, Employee>();
        CreateMap<Product, ProductDTO>();
        CreateMap<ProductDTO, Product>();
        CreateMap<CustomerProductEmployee, CustomerProductEmployeeDTO>();
        CreateMap<CustomerProductEmployeeDTO, CustomerProductEmployee>();
        CreateMap<PurchaseDTO, CustomerProductEmployee>();
        CreateMap<CustomerProductEmployee, PurchaseDTO>();

    }
}