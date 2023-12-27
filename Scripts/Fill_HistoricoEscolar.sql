


INSERT INTO HistoricoEscolar (Formato, Nome, Arquivo)
 SELECT 'PDF' as Formato, 'Historico A3' as Nome
 , BulkColumn FROM Openrowset( Bulk '/var/tmp/pdfs/SCAN0264.pdf', Single_Blob) as Arquivo;
