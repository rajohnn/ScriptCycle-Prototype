/****** Object:  StoredProcedure [dbo].[FindByNDC]    Script Date: 2/25/2019 7:35:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FindByNDC]
	@NDC varchar(20)
AS
BEGIN	
	SET NOCOUNT ON;
    
	SELECT 	  
      FName.[drug_name]
	  ,(Select tcgpi_name from mf2tcgpi_g where tcgpi_id = FName.generic_product_identifier) as DisplayName     
      ,FName.[dosage_form]
      ,FName.[strength]
      ,FName.[strength_unit_of_measure]  
      ,FName.[generic_product_identifier]      
	  ,NDC.ndc_upc_hri      
	  ,FName.[multi_source_code]
	  ,FName.[maintenance_drug_code]
  FROM [mf2name_f] FName	
	join mf2ndc_h NDC on NDC.drug_descriptor_id = FName.drug_descriptor_id
  where NDC.ndc_upc_hri like @NDC + '%'
  order by generic_product_identifier

	
END
GO


