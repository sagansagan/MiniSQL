CREATE TABLE "public"."san_project" ( 
  "id" SERIAL,
  "project_name" VARCHAR(35) NOT NULL,
  CONSTRAINT "san_project_pkey" PRIMARY KEY ("id"),
  CONSTRAINT "san_project_name" UNIQUE ("project_name")
);
CREATE TABLE "public"."san_project_person" ( 
  "id" SERIAL,
  "project_id" INTEGER NOT NULL,
  "person_id" INTEGER NOT NULL,
  "hours" INTEGER NOT NULL,
  CONSTRAINT "san_project_person_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."san_person" ( 
  "id" SERIAL,
  "person_name" VARCHAR(20) NOT NULL,
  CONSTRAINT "san_person_pkey" PRIMARY KEY ("id"),
  CONSTRAINT "san_person_name" UNIQUE ("person_name")
);
ALTER TABLE "public"."san_project_person" ADD CONSTRAINT "FK_san_project_person_project_id" FOREIGN KEY ("project_id") REFERENCES "public"."san_project" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."san_project_person" ADD CONSTRAINT "FK_san_person_project_person_id" FOREIGN KEY ("person_id") REFERENCES "public"."san_person" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;

INSERT INTO "san_person" ("id", "person_name") VALUES (1, 'Saga');