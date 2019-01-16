using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reiniciar_Projeto
{
	class Program
	{
		static void Main(string[] args)
		{
			bool verificado = false;
			string pasta = Directory.GetCurrentDirectory();

            string ambiente = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.nuget";
            string[] ambientepackages = Directory.GetDirectories(ambiente, "ICICore*.*", SearchOption.AllDirectories);
            string[] diretorios = Directory.GetDirectories(pasta);
			string[] diretoriosBin = Directory.GetDirectories(pasta, "bin", SearchOption.AllDirectories);
			string[] diretoriosObj = Directory.GetDirectories(pasta, "obj", SearchOption.AllDirectories);
			string[] arquivosLock = Directory.GetFiles(pasta, "*.lock.json", SearchOption.AllDirectories);
			string[] arquivoConfig = Directory.GetFiles(pasta, "applicationhost.config", SearchOption.AllDirectories);

			if (arquivosLock.Length == 0 && diretoriosBin.Length == 0 && arquivoConfig.Length == 0)
			{
				Console.WriteLine("Arquivos .lock, arquivo applicationhost e/ou Pastas Bin não encontrados");
				//MessageBox.Show("Arquivos .lock, arquivo applicationhost e/ou Pastas Bin não encontrados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				verificado = true;
			}
			else
			{
				if (arquivosLock.Length == 0)
				{
					//MessageBox.Show("Não há arquivos .lock para deletar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					verificado = true;
				}
				else
				{
					foreach (string arq in arquivosLock)
					{
						try
						{
							File.Delete(arq);
							verificado = true;
						}
						catch (Exception)
						{
							verificado = false;
							//MessageBox.Show("Erro ao deletar arquivos", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
							throw;
						}
					}
				}
				if (arquivoConfig.Length == 0)
				{
					verificado = true;
					//MessageBox.Show("Não há arquivos appConfig para deletar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				else
				{
					foreach (string arq in arquivoConfig)
					{
						try
						{
							File.Delete(arq);
							verificado = true;
						}
						catch (Exception)
						{
							verificado = false;
							//MessageBox.Show("Erro ao deletar arquivos", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
							throw;
						}
					}
				}
				if (diretoriosBin.Length == 0)
				{
					verificado = true;
					//MessageBox.Show("Não há pastas Bin para deletar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				else
				{
					foreach (string arq in diretoriosBin)
					{
						try
						{
							Directory.Delete(arq, true);
							verificado = true;
						}
						catch (Exception)
						{
							verificado = false;
							//MessageBox.Show("Erro ao deletar pastas", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
							throw;
						}
					}
				}
                if (diretoriosObj.Length == 0)
                {
                    verificado = true;
                    //MessageBox.Show("Não há pastas Bin para deletar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    foreach (string arq in diretoriosObj)
                    {
                        try
                        {
                            Directory.Delete(arq, true);
                            verificado = true;
                        }
                        catch (Exception)
                        {
                            verificado = false;
                            //MessageBox.Show("Erro ao deletar pastas", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw;
                        }
                    }
                }
                if(ambientepackages.Length == 0)
                {
                    verificado = true;
                }
                else
                {
                    foreach (string arq in ambientepackages)
                    {
                        try
                        {
                            Directory.Delete(arq, true);
                            verificado = true;

                        }
                        catch (Exception)
                        {
                            verificado = false;
                            //MessageBox.Show("Erro ao deletar pastas", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw;
                        }
                    }
                }
                if (verificado == true)
						{
							Console.WriteLine("Arquivos deletados com sucesso.");
							//MessageBox.Show("Arquivos deletados com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						else
						{
							Console.WriteLine("Falha ao deletar os arquivos.");
							//MessageBox.Show("Falha ao deletar os arquivos.", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}

            }
}