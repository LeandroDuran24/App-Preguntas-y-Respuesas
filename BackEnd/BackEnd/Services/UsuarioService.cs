﻿using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;

namespace BackEnd.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {

            _usuarioRepository = usuarioRepository;
        }

        public async Task SaveUser(Usuario user)
        {
            await _usuarioRepository.SaveUser(user);
        }

        public async Task<bool>ValidateExistence(Usuario usuario)
        {
             return await _usuarioRepository.ValidateExistence(usuario);

        }

        public async Task<Usuario> ValidatePassword(int idUsuario,string passwordAnterior)
        {
            return await _usuarioRepository.ValidatePassword(idUsuario, passwordAnterior);

        }

       public async Task UpdatePassword(Usuario usuario)
        {
             await _usuarioRepository.UpdatePassword(usuario);
        }




       

    }
}
