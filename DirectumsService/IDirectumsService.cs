﻿using System;
using System.ServiceModel;
using Directums.Classes;
using Directums.Service.Classes;

namespace Directums.Service
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IDirectumsServiceCallback))]
    public interface IDirectumsService
    {
        [OperationContract]
        bool Connect(string login, string passwordHash);

        [OperationContract(IsOneWay = true)]
        void Disconnect();

        [OperationContract]
        User GetCurrentUser();

        [OperationContract]
        User[] UserList();

        [OperationContract]
        bool AddUser(string login, string email, string passwordHash);

        [OperationContract]
        bool IsLoginEmpty(string login);

        [OperationContract]
        bool IsEmailEmpty(string email);

        [OperationContract(IsOneWay = true)]
        void AddMessage(int idUserFor, string text);

        [OperationContract]
        FindUsersResult FindUsers(int page, UserFilter filter);

        [OperationContract(IsOneWay = true)]
        void ResetUserPassword(int idUser);

        [OperationContract(IsOneWay = true)]
        void UpdateUser(int idUser, string login, string email, byte status);
    }
}