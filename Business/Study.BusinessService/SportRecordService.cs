﻿using System;
using Study.Entity;
using Study.BusinessService.Application;
using EmitMapper;
using EmitMapper.MappingConfiguration;
using System.Collections.Generic;
using Excel;
using System.IO;

namespace Study.BusinessService
{
    public class SportRecordService : ServiceStudyBaseIntId<SportRecord, SportRecordDto, SportRecordQuery>, ISportRecordService
    {
        public SportRecordService()
        {
        }
        protected override SportRecordDto ToDto(SportRecord entity)
        {
            return null;
        }
        protected override SportRecord ToEntity(SportRecordDto dto)
        {
            var mapper = new ObjectMapperManager().
               GetMapper<SportRecordDto, SportRecord>(new DefaultMapConfig().ConvertUsing<SportRecordDto, SportRecord>(value => new SportRecord(value.Id)
               {
                   Id = value.Id,
                   ActivityKind =Convert.ToInt16( dto.SportName),
                   ActivityTime = value.ActivityTime,
                   Numbers = value.Numbers,
                   Remark = value.Remark,
               }));
            SportRecord entity = mapper.Map(dto);
            return entity;
        }
        public override SportRecordDto Create()
        {
            SportRecordDto dto = new SportRecordDto();
            dto.ActivityTime = DateTime.Now;
            return dto;
        }

        public override string GetQuerySqlId()
        {
            return "qSportRecord";
        }
        public override string GetQuerySqlWithParameterIsId()
        {
            return "qSportRecordId";
        }
        
        public override string GetDeleteSqlId()
        {
            return "dSportRecord";
        }
        public override string GetInsertSqlId()
        {
            return "iSportRecord";
        }
        public override string GetUpdateSqlId()
        {
            return "uSportRecord";
        }

        public override MemoryStream ExportExcel(IList<SportRecordDto> content)
        {
            Utility excelUtility = new Utility();
            excelUtility.CreateExcelSheet();
            string header = "项目,时间,数量";
            excelUtility.WriteDataToSheet(header, 0);
            if (content != null)
            {
                for (int i = 0; i < content.Count; i++)
                {
                    SportRecordDto model = content[i];
                    string Line = model.SportName + "," + model.ActivityTime.ToString("yyyy/MM/dd HH:mm:ss") + "," + model.Numbers;
                    excelUtility.WriteDataToSheet(Line, i + 1);
                }
            }
            MemoryStream ms = excelUtility.SaveToMemoryStream();

            return ms;
        }
    }
}