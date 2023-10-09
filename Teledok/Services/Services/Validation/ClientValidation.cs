using Teledok.Models;
using Teledok.Models.Enums;

namespace Teledok.Services.Validation;

public class ClientValidation
{
    private readonly ClientViewModel _client;
    private List<(string errorKey, string errorMessage)> errorList;
    public ClientValidation(ClientViewModel client)
    {
        _client = client;
        errorList = new();
    }

    public List<(string errorKey, string errorMessage)> Validate()
    {
        ValidateInn();
        ValidateFounders();
        return errorList;
    }

    private void ValidateInn()
    {
        if (_client.INN == null)
        {
            errorList.Add(("INN","ИНН должен быть заполнен!"));
            return;
        }
        ValidateInnValue();
        ValidateInnLength();
    }

    private void ValidateInnValue()
    {
        var result = _client.INN.All(char.IsDigit);
        if (!result)
            errorList.Add(("INN","В поле ИНН должны быть только цифры!"));
    }
    
    private void ValidateInnLength()
    {
        if (_client.ClientType == (int)ClientTypes.JuridicalPerson)
        {
            if (_client.INN.Length != 10)
            {
                errorList.Add(("INN","Длина ИНН у юридического лица должна быть 10 цифр"));
            }
        }

        if (_client.ClientType == (int)ClientTypes.IndividualEntrepreneur)
        {
            if (_client.INN.Length != 12)
            {
                errorList.Add(("INN","Длина ИНН у ИП должна быть 10 цифр"));
            }
        }
    }

    private void ValidateFounders()
    {
        if (_client.Founders == null)
            errorList.Add(("Founders","Должен быть указан хотя бы один учредитель!"));
            
        
        if ((_client.ClientType == (int)ClientTypes.IndividualEntrepreneur) && (_client.Founders != null))
        {
            if (_client.Founders.Length > 1)
            {
                errorList.Add(("Founders","У ИП не может быть больше одного учредителя"));
            }
        }
    }
    
    
}