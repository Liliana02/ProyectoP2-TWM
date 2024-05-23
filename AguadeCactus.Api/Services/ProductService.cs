﻿using AguadeCactus.Api.Dto;
using AguadeCactus.Api.Repositories.Interfaces;
using AguadeCactus.Api.Services.Interfaces;
using AguadeCactus.Core.Entities;

namespace AguadeCactus.Api.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<bool> ProductExist(int id)
    {
        var product = await _productRepository.GetById(id);
        return (product != null);
    }

    public async Task<ProductDto> SaveAsync(ProductDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price,
            Size= productDto.Size,
            IdCategory = productDto.IdCategory,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        product = await _productRepository.SaveAsync(product);
        productDto.id = product.id;

        return productDto;
    }

    public async Task<ProductDto> UpdateAsync(ProductDto productDto)
    {
        var product = await _productRepository.GetById(productDto.id);
        
        if (product == null)
            throw new Exception("Product Not Found");
        
        product.Name = productDto.Name;
        product.Description = productDto.Description;
        product.Price = productDto.Price;
        product.Size = productDto.Size;
        product.IdCategory = productDto.IdCategory;
        product.UpdatedBy = "";
        product.UpdatedDate = DateTime.Now;
        await _productRepository.UpdateAsync(product);
        
        return productDto;
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();
        var productsDto =
            products.Select(c => new ProductDto(c)).ToList();
        return productsDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _productRepository.DeleteAsync(id);
    }

    public async Task<ProductDto> GetById(int id)
    {
        var product = await _productRepository.GetById(id);
        if (product == null)
            throw new Exception("Product not Found");
        
        var productDto = new ProductDto(product);
        return productDto;
    }
    
    //Metodo category
    private async Task<CategoryDto> GetCategoryForProduct(int productId)
    {
        int categoryId = await _productRepository.GetCategoryIdByProductId(productId);
        var category = await _categoryRepository.GetById(categoryId);
        
        var categoryDto = new CategoryDto
        {
            id = category.id,
            Name = category.Name,
            Description = category.Description
        };

        return categoryDto;
    }
    
}