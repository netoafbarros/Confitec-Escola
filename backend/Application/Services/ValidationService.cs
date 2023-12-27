using ConfitecEscola.Application.Domain.Escolaridades.Command;
using ConfitecEscola.Application.Domain.HistoricosEscolares.Command;
using ConfitecEscola.Application.Domain.Usuarios.Command;
using ConfitecEscola.Application.Domain.Usuarios.Queries;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ConfitecEscola.Application.Services
{
    public class ValidationService : IValidationService
    {
        private readonly int MIN_ESCOLARIDADE = 1;
        private readonly int MAX_ESCOLARIDADE = 4;
        private readonly int MIN_AGE = 15;
        public void Validate<T>(T obj)
        {
            if (obj != null)
            {
                if (obj is NewUsuarioRequestCommand)
                {
                    NewUsuarioValidate(obj);
                }

                if (obj is UpdateUsuarioRequestCommand)
                {
                    UpdUsuarioValidate(obj);
                }

                if (obj is DeleteUsuarioRequestCommand)
                {
                    DelUsuarioValidate(obj);
                }

                if (obj is NewEscolaridadeRequestCommand)
                {
                    NewEscolaridadeValidate(obj);
                }

                if (obj is UpdateEscolaridadeRequestCommand)
                {
                    UpdEscolaridadeValidate(obj);
                }


                if (obj is GetUsuariosRequestQuery)
                {
                    GetUsuarioValidate(obj);
                }
            }
        }



        #region Usuário
        private void NewUsuarioValidate<T>(T obj)
        {
            var objToValidate = (obj as NewUsuarioRequestCommand);
            if (objToValidate?.Nome.Trim().Length == 0)
            {
                throw new ValidationException("Erro de validação do usuário - Nome não foi preenchido");
            }

            if (objToValidate?.Sobrenome.Trim().Length == 0)
            {
                throw new ValidationException("Erro de validação do usuário - Sobrenome não foi preenchido");
            }

            #region Email Validation

            if (objToValidate?.Email.Trim().Length == 0)
            {
                throw new ValidationException("Erro de validação do usuário - Email não foi preenchido");
            }

            var email = objToValidate?.Email.Trim();
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
                throw new ValidationException("Erro de validação do usuário - Email inválido");
            }

            #endregion

            if (objToValidate?.DataNascimento.ToShortDateString().Trim().Length == 0)
            {
                throw new ValidationException("Erro de validação do usuário - DataNascimento não foi preenchido");
            }

            if (CalculaQtdAnosIdade(objToValidate.DataNascimento) < MIN_AGE)
            {
                throw new ValidationException("Erro de validação do usuário - DataNascimento menor que 15 anos");
            }

            if (objToValidate?.IdEscolaridade < this.MIN_ESCOLARIDADE || objToValidate?.IdEscolaridade > this.MAX_ESCOLARIDADE)
            {
                throw new ValidationException("Erro de validação do usuário - Escolaridade inválido");
            }
        }

        private void UpdUsuarioValidate<T>(T obj)
        {
            var objToValidate = (obj as UpdateUsuarioRequestCommand);

            if (objToValidate?.IdUsuario == 0)
            {
                throw new ValidationException("Erro de validação do usuário - Id do Usuário não foi preenchido");
            }
            if (objToValidate?.Nome.Trim().Length == 0)
            {
                throw new ValidationException("Erro de validação do usuário - Nome não foi preenchido");
            }

            if (objToValidate?.Sobrenome.Trim().Length == 0)
            {
                throw new ValidationException("Erro de validação do usuário - Sobrenome não foi preenchido");
            }

            #region Email Validation

            if (objToValidate?.Email.Trim().Length == 0)
            {
                throw new ValidationException("Erro de validação do usuário - Email não foi preenchido");
            }

            var email = objToValidate?.Email.Trim();
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
                throw new ValidationException("Erro de validação do usuário - Email inválido");
            }

            #endregion

            if (objToValidate?.DataNascimento.ToShortDateString().Trim().Length == 0)
            {
                throw new ValidationException("Erro de validação do usuário - DataNascimento não foi preenchido");
            }

            if (CalculaQtdAnosIdade(objToValidate.DataNascimento) < MIN_AGE)
            {
                throw new ValidationException("Erro de validação do usuário - DataNascimento menor que 15 anos");
            }

            if (objToValidate?.IdEscolaridade < this.MIN_ESCOLARIDADE || objToValidate?.IdEscolaridade > this.MAX_ESCOLARIDADE)
            {
                throw new ValidationException("Erro de validação do usuário - Escolaridade inválido");
            }
        }

        private void DelUsuarioValidate<T>(T obj)
        {
            var objToValidate = (obj as DeleteUsuarioRequestCommand);

            if (objToValidate?.IdUsuario == 0)
            {
                throw new ValidationException("Erro de validação do usuário - Id do Usuário não foi preenchido");
            }
        }

        public static int CalculaQtdAnosIdade(DateTime data, DateTime? now = null)
        {
            // Carrega a data do dia para comparação caso data informada seja nula

            now = ((now == null) ? DateTime.Now : now);

            try
            {
                int YearsOld = (now.Value.Year - data.Year);

                if (now.Value.Month < data.Month || (now.Value.Month == data.Month && now.Value.Day < data.Day))
                {
                    YearsOld--;
                }

                return (YearsOld < 0) ? 0 : YearsOld;
            }
            catch
            {
                return 0;
            }
        }

        private void GetUsuarioValidate<T>(T obj)
        {
            var objToValidate = (obj as GetUsuariosRequestQuery);

            if (objToValidate?.IdUsuario == 0)
            {
                throw new ValidationException("Erro de validação da usuário - Id da Usuário não foi preenchido");
            }
        }

        #endregion

        #region Escolaridade
        private void NewEscolaridadeValidate<T>(T obj)
        {
            var objToValidate = (obj as NewEscolaridadeRequestCommand);
            if (objToValidate?.Escolaridade.Trim().Length == 0)
            {
                throw new ValidationException("Erro de validação da escolaridade - Escolaridade não foi preenchida");
            }
        }

        private void UpdEscolaridadeValidate<T>(T obj)
        {
            var objToValidate = (obj as UpdateEscolaridadeRequestCommand);

            if (objToValidate?.IdEscolaridade == 0)
            {
                throw new ValidationException("Erro de validação da escolaridade - Id da Escolaridade não foi preenchido");
            }

            if (objToValidate?.Escolaridade.Trim().Length == 0)
            {
                throw new ValidationException("Erro de validação da escolaridade - Escolaridade não foi preenchida");
            }
        }

        #endregion

        
    }
}
