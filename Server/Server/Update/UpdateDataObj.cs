﻿using System.Collections.Generic;
using Server.DataClasses;

namespace Server.Update
{
    public static partial class UpdateDataObj
    {
		public static readonly  List<GetObject> ClassGetObjects = new List<GetObject>();  //Список 

        public class DataObject
        {
	        public string NameDataObj { get; }			//Путь до класса  
			public int  IndexDataOBj { get; }				//Индекс для дискретного канала
            public BaseClass DataObj { get; }					//Ссылка на объект управления

	        public DataObject(string nameDataObj, int indexDataOBj, BaseClass dataObj)
	        {
		        NameDataObj = nameDataObj;
		        IndexDataOBj = indexDataOBj;
		        DataObj = dataObj;
	        }
		}

	    public class GetObject
	    {
		    public ushort AddrObj { get; }			 //Адрес куда писать или откуда брать данные
		    public ushort ByteObj { get; }			//Колличество байт
		    public bool TypeObj { get; }              //Тип получаймых данных Дискретные или Аналоговые

		    public List<DataObject> DataClass = new List<DataObject>();              //Ссылка на управляймые объекты
			public BitArrayObj BitArray { get; set; }                        //Битовое поле для Дискретных объектов 

			public GetObject(ushort addrObj, ushort byteObj, bool typeObj)
			{
				AddrObj = addrObj;
				ByteObj = byteObj;
				TypeObj = typeObj;
			}
	    }
	}
}
