﻿using AutoMapper;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository {
    public class CategoryRepository : ICategoryRepository {

        private DataContext _context;

        public CategoryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
        }

        public bool CategoryExists (int id) {
            return _context.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories() {
            return _context.Categories.ToList();
        }

        public Category GetCategory (int id) {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory (int categoryId) {
            return _context.PokemonCategories.Where(c => c.CategoryId == categoryId).Select(p => p.Pokemon).ToList();
        }
    }
}
