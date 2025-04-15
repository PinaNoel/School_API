

using School_API.App.DTO;

namespace School_API.Core.Exceptions
{
    public class ModelStateException : Exception
    {
        public List<ModelStateErrorsDTO> Errors { get; }

        public ModelStateException(List<ModelStateErrorsDTO> errors) : base ("Model State is invalid")
        {
            Errors = errors;
        } 
    }
}