﻿using JujutsuKaisen.Models.DTO;
using JujutsuKaisen.Models.Model;

namespace JujutsuKaisen.Repository.Service
{
    public interface ICharacters
    {
        public Task<List<Characters>> Characters_GETS();

        public Task<Characters> Character_GET(int id);

        public Task<Characters> Character_POST(CharactersDTO character);

        public Task<bool> Character_PUT(CharactersDTO character, int id);

        public Task<bool> Character_DELETE(int id);
    }
}