using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CompAndDel.Filters;

namespace CompAndDel.Pipes
{
    public class PipeNull : IPipe
    {
        protected IFilter faceRecognition;
        IPicture image;
        /// <summary>
        /// Recibe una imagen, la guarda en una variable image y la retorna.
        /// </summary>
        /// <param name="picture">Imagen a recibir</param>
        /// <returns>La misma imagen</returns>
        public IPicture Send(IPicture picture)
        {
            this.image = picture;
            this.faceRecognition = new FilterFaceRecognition();
            this.faceRecognition.Filter(picture);
            return this.image;
        }

    }
}
