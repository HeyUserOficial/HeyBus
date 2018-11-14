using HeyBus.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HeyBus.Models
{
    public class Cliente : Acesso
    {
        [Key]
        [Display(Name = ("Código"))]
        public int id_Cliente { get; set; }

        [Display(Name = "CPF")]
        [MaxLength(14)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Preencha o campo CPF corretamente")]
        public string cpf_Cliente { get; set; }

        [Display(Name = "Nome Completo", Description = "Nome e Sobrenome.")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
        "Números e caracteres especiais não são permitidos no nome.")]
        [MaxLength(70)]
        public string nome_Cliente { get; set; }

        [Display(Name = "Nascimento"), DataType(DataType.Date),
        DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime nascimento_Cliente { get; set; }

        [Display(Name = "Telefone"), MaxLength(20), Required]
        public string tel_Cliente { get; set; }

        [Display(Name = "Celular"), MaxLength(20), Required]
        public string cel_Cliente { get; set; }

        [Display(Name = "E-mail")]
        [MaxLength(60)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Informe o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido!")]
        public string email_Cliente { get; set; }
        
        [Display(Name = "Nome de usuário")]
        [MaxLength(25, ErrorMessage = "Número de caracteres chegou ao limite")]
        [MinLength(6, ErrorMessage = "Número de caracteres muito pequeno")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Preencha o campo de usuário corretamente")]
        public string usuario_Cliente { get; set; }

        [Display(Name = "Senha de usuário")]
        [MaxLength(25, ErrorMessage = "Número de caracteres chegou ao limite")]
        [MinLength(6, ErrorMessage = "Número de caracteres muito pequeno")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Preencha o campo de senha corretamente")]
        [DataType(DataType.Password)]
        public string senha_Cliente { get; set; }

        [Display(Name = "Confirme a senha")]
        [MaxLength(25, ErrorMessage = "Número de caracteres chegou ao limite")]
        [MinLength(6, ErrorMessage = "Número de caracteres muito pequeno")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Preencha o campo de senha corretamente")]
        [DataType(DataType.Password)]
        [Compare("senha_Cliente", ErrorMessage = "Senha não compatível")]
        public string confirma_Senha { get; set; }

        public System.Guid ativacao_Cliente { get; set; }

        public bool email_Verify { get; set; }
    }
}