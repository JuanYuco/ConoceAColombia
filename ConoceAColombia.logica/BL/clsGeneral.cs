﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.BL
{
    public class clsGeneral
    {
        public void setEmail(Models.clsCorreo obclsCorreo)
        {
            try
            {
                MailMessage Mail = new MailMessage();

                Mail.From = new MailAddress(obclsCorreo.stFrom);
                Mail.To.Add(obclsCorreo.stTo);
                Mail.Subject = obclsCorreo.stAsunto;
                Mail.Body = obclsCorreo.stMensaje;

                if (obclsCorreo.inTipo == 0) Mail.IsBodyHtml = false;
                else if (obclsCorreo.inTipo == 1) Mail.IsBodyHtml = true;

                if (obclsCorreo.inPrioridad == 2) Mail.Priority = MailPriority.High;
                if (obclsCorreo.inPrioridad == 1) Mail.Priority = MailPriority.Low;
                if (obclsCorreo.inPrioridad == 0) Mail.Priority =MailPriority.Normal;


                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(obclsCorreo.stMensaje,
                    Encoding.UTF8,
                    MediaTypeNames.Text.Html);

                LinkedResource img = new LinkedResource(obclsCorreo.stImage, MediaTypeNames.Image.Jpeg);
                img.ContentId = obclsCorreo.stIdImage;
                htmlView.LinkedResources.Add(img);


                Mail.AlternateViews.Add(htmlView);
                SmtpClient smtp = new SmtpClient();
                smtp.Host = obclsCorreo.stServidor;

                if (obclsCorreo.blAutenticacion) smtp.Credentials = new System.Net.NetworkCredential(obclsCorreo.stUsuario, obclsCorreo.stPassword);
                if (obclsCorreo.stPuerto.Length > 0) smtp.Port = Convert.ToInt32(obclsCorreo.stPuerto);

                smtp.EnableSsl = obclsCorreo.blConexionSegura;
                smtp.Send(Mail);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
