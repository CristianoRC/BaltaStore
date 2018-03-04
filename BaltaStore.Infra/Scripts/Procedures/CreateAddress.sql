CREATE OR REPLACE FUNCTION public.CreateAddress
                    (text,text,varchar,varchar,varchar,varchar,varchar,varchar,varchar,int)
RETURNS void
LANGUAGE plpgsql
AS 
$function$
BEGIN
    insert into address values($1,$2,$3,$4,$5,$6,$7,$8,$9,$10);
END;
$function$