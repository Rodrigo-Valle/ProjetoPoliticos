using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminAPI.DTO.InputModel;
using System.Security.Cryptography;
using System.Text;
using AdminAPI.Models;
using AdminAPI.Data;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using AdminAPI.Exceptions;

namespace AdminAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _database;
        public UsuarioService(AppDbContext database)
        {
            _database = database;
        }

        public Task CadastrarUsuario(UsuarioInputModel usuario)
        {
            var hash = HashSenha(usuario.Senha);
            Usuario u = new Usuario();
            u.User = usuario.Usuario;
            u.Senha = hash;
            u.Admin = usuario.Admin;
            _database.Usuarios.Add(u);
            _database.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<string> Login(LoginInputModel login)
        {
            var usuario = _database.Usuarios.FirstOrDefault(x => x.User == login.Usuario);
            if (usuario != null)
            {
                if (usuario.Senha.Equals(HashSenha(login.Senha)))
                {
                    string ChaveSeguranca = "TesteChaveSeguranca";
                    var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ChaveSeguranca));
                    var tokenAcesso = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256Signature);

                    var claims = new List<Claim>();
                    claims.Add(new Claim("id", usuario.Id.ToString()));
                    claims.Add(new Claim("Usuario", usuario.User));

                    if (usuario.Admin == true)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    }

                    var JWT = new JwtSecurityToken(
                        issuer: "sistema",
                        expires: DateTime.Now.AddHours(1),
                        audience: "usuario",
                        signingCredentials: tokenAcesso,
                        claims: claims
                    );
                    var token = new JwtSecurityTokenHandler().WriteToken(JWT);
                    return Task.FromResult(token);
                }
                else
                {
                    throw new UnauthorizedAccessException("Senha incorreta");
                }
            }
            else
            {
                throw new ObjetoNaoLocalizadoException("Usuario não localizado");
            }
        }

        public static string HashSenha(string password)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] senha_bytes = Encoding.ASCII.GetBytes(password);
            byte[] encrypted_bytes = sha1.ComputeHash(senha_bytes);
            return Convert.ToBase64String(encrypted_bytes);
        }
    }
}