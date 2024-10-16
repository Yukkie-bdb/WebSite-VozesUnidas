﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using NuGet.Packaging;
using WebSiteVozesUnidas.Models;

namespace WebSiteVozesUnidas.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private string _caminho;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IWebHostEnvironment hostEnvironment)
        {
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
            public string Sobre { get; set; }
            public TipoUsuario Tipo { get; set; }
            public DateOnly Nascimento { get; set; }
            public List<string> Habilidades { get; set; } = new List<string>();
            public string Objetivos { get; set; }
            public bool Jornalista { get; set; }
            public string CPF { get; set; }
            public string CNPJ { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Foto = user.Foto,
                Nome = user.UserName,
                Email = user.Email,
                Sobre = user.Sobre,
                Tipo = user.Tipo,
                Nascimento = (DateOnly)user.Nascimento,
                Habilidades = user.Habilidades,
                Objetivos = user.Objetivos,
                Jornalista = user.Jornalista,
                CPF = user.CPF,
                CNPJ = user.CNPJ
            };
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

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

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
            user.UserName = Input.Nome;
            user.Email = Input.Email;
            user.Sobre = Input.Sobre;
            user.Tipo = Input.Tipo;
            user.Nascimento = Input.Nascimento;
            user.Habilidades = Input.Habilidades;
            user.Objetivos = Input.Objetivos;
            user.Jornalista = Input.Jornalista;
            user.CPF = Input.CPF;
            user.CNPJ = Input.CNPJ;

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
    }
}
