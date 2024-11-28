// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.CodeAnalysis.Elfie.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using NuGet.Packaging;
using SQLitePCL;
using WebSiteVozesUnidas.Data;
using WebSiteVozesUnidas.Models;

namespace WebSiteVozesUnidas.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private string _caminho;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IWebHostEnvironment hostEnvironment,
            ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _caminho = hostEnvironment.WebRootPath;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            public string Foto { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Ramo { get; set; }
            public string Sobre { get; set; }
            public string Estado { get; set; }
            public string Cidade { get; set; }
            public string Portifolio { get; set; }
            public TipoUsuario Tipo { get; set; }
            public DateOnly? Nascimento { get; set; }
            public int? NascimentoDia { get; set; }
            public int? NascimentoMes { get; set; }
            public int? NascimentoAno { get; set; }
            public List<string> Habilidades { get; set; } = new List<string>();
            public string Objetivos { get; set; }
            public bool Jornalista { get; set; }
            public string CPF { get; set; }
            public string CPFNovo { get; set; }
            public string CNPJ { get; set; }
            public string CNPJNovo { get; set; }
            public int Funcionarios { get; set; }
            public List<VagaEmprego> Vagas { get; set; }
            public List<VagaEmprego> VagasCandidatadas { get; set; }
            public List<AvaliacaoEspecialista> Avaliacoes { get; set; }
            public List<Noticia> Noticias { get; set; }
            public List<Post> Posts { get; set; }
            public int Comentarios { get; set; }

        }

        private async Task LoadAsync(ApplicationUser user)
        {
            //var userName = await _userManager.GetUserNameAsync(user);
            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            user = await _userManager.GetUserAsync(User);

            Username = user.UserName;

            Input = new InputModel
            {
                PhoneNumber = user.PhoneNumber,
                Foto = user.Foto,
                Nome = user.UserName,
                Email = user.Email,
                Sobre = user.Sobre,
                Tipo = user.Tipo,
                Nascimento = user.Nascimento,
                Objetivos = user.Objetivos,
                Jornalista = user.Jornalista,
                CPF = user.CPF,
                CNPJ = user.CNPJ,
                Estado = user.Estado,
                Cidade = user.Cidade,
                Portifolio = user.Portifolio,
                Ramo = user.Ramo,

            };

            Input.Avaliacoes = _context.AvaliacaoEspecialistas.Include(u => u.Especialistas).Where(u => u.UsuarioId == user.Id).ToList();
            Input.Noticias = _context.Noticias.Where(u => u.Id == user.Id).OrderBy(u => u.Publicacao).Take(6).ToList();
            Input.Posts = _context.Posts.Where(u => u.Id == user.Id).Include(p => p.Likes).Include(o => o.Comentarios).OrderByDescending(u => u.Likes.Count()).Take(3).ToList();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            await LoadAsync(user);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(IFormFile imgUp)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            //if (!ModelState.IsValid)
            //{
            //    await LoadAsync(user);
            //    return Page();
            //}

            // Se houver uma ImagemPerfil existente, excluí-la
            if (Input.Foto != null)
            {
                if (!string.IsNullOrEmpty(user.Foto))
                {
                    string existingFilePath = Path.Combine(_caminho, "img", user.Foto);
                    if (System.IO.File.Exists(existingFilePath))
                    {
                        System.IO.File.Delete(existingFilePath);
                    }
                }
            }

            if (imgUp != null && imgUp.Length > 0)
            {
                string uploadsFolder = Path.Combine(_caminho, "img");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + imgUp.FileName;

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imgUp.CopyToAsync(fileStream);
                }
                user.Foto = uniqueFileName;
            }

            //Input.Habilidades = user.Habilidades;

            // Atualizar todas as propriedades
            //user.UserName = Input.Nome;
            //user.Email = Input.Email;
            user.Sobre = Input.Sobre;
            //user.Tipo = Input.Tipo;
            user.Nascimento = Input.Nascimento;
            user.Objetivos = Input.Objetivos;
            //user.Jornalista = Input.Jornalista;
            //user.CPF = Input.CPF;
            //user.CNPJ = Input.CNPJ;
            user.Estado = Input.Estado;
            user.Cidade = Input.Cidade;
            user.Portifolio = Input.Portifolio;

            // Se o usuário não preencher a data, deixar Nascimento como null
            if (Input.NascimentoAno.HasValue && Input.NascimentoMes.HasValue && Input.NascimentoDia.HasValue)
            {
                try
                {
                    user.Nascimento = new DateOnly(Input.NascimentoAno.Value, Input.NascimentoMes.Value, Input.NascimentoDia.Value);
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Se a data for inválida (como um dia de mês inexistente), você pode definir uma mensagem de erro
                    StatusMessage = "A data de nascimento informada é inválida.";
                }
            }
            else
            {
                // Se não for fornecida uma data completa, manter o Nascimento como null
                user.Nascimento = null;
            }



            // Atualizar o telefone separadamente
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                StatusMessage = "Unexpected error when trying to update profile.";
                return RedirectToPage();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCpfPostar()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (Input.CPFNovo != user.CPF)
            {
                user.CPF = Input.CPFNovo;

                await _userManager.UpdateAsync(user);
                await _signInManager.RefreshSignInAsync(user);
                return RedirectToPage();
            }

            StatusMessage = "CPF não alterado, igual ao anterior!!.";
            return RedirectToPage();

        }
            public async Task<IActionResult> OnPostCnpjPostar()
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                }

            if (Input.CNPJNovo != user.CNPJ)
            {
                user.CNPJ = Input.CNPJNovo;

                await _userManager.UpdateAsync(user);
                    await _signInManager.RefreshSignInAsync(user);
                    return RedirectToPage();
                }

            StatusMessage = "CNPJ não alterado, igual ao anterior!!.";
            return RedirectToPage();

        }

        public async Task<IActionResult> OnPostNome()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!string.IsNullOrEmpty(Input.Nome))
            {
                // Verificar se já existe um usuário com o mesmo nome
                var existingUser = await _userManager.FindByNameAsync(Input.Nome);

                if (existingUser != null && existingUser.Id != user.Id) // Checar se o nome pertence a outro usuário
                {
                    StatusMessage = "Este nome já está em uso por outro usuário.";
                    return RedirectToPage();
                }

                // Atualizar o nome se ele não estiver em uso
                user.UserName = Input.Nome;

                var updateResult = await _userManager.UpdateAsync(user);
                if (updateResult.Succeeded)
                {
                    await _signInManager.RefreshSignInAsync(user);
                    StatusMessage = "Nome alterado com sucesso!";
                }
                else
                {
                    StatusMessage = "Erro ao tentar alterar o nome.";
                }

                return RedirectToPage();
            }

            StatusMessage = "Nome não alterado!";
            return RedirectToPage();
        }


    }
}