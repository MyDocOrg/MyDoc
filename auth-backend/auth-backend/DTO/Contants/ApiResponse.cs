using System;
using System.Collections.Generic;
using System.Text;

namespace auth_backend.DTO.Contants
{
    public class ApiResponse<T>
    {
        public int Status { get; set; } = C.STATUS_OK;
        public string Mensaje { get; set; } = C.OK;
        public T Data { get; set; }

        public ApiResponse() { }

        public ApiResponse(T data)
        {
            Data = data;
            Status = C.STATUS_OK;
            Mensaje = C.OK;
        }

        public ApiResponse(string mensaje, int status = C.STATUS_ERROR)
        {
            Status = status;
            Mensaje = mensaje;
        }

        // Método estático para respuesta exitosa
        public static ApiResponse<T> Ok(T data, string message = C.OK)
        {
            return new ApiResponse<T>
            {
                Status = C.STATUS_OK,
                Mensaje = message,
                Data = data
            };
        }

        // Método estático para respuesta fallida
        public static ApiResponse<T> Fail(string message = C.ERROR, int status = C.STATUS_ERROR, T data = default)
        {
            return new ApiResponse<T>
            {
                Status = status,
                Mensaje = message,
                Data = data
            };
        }
    }
}

