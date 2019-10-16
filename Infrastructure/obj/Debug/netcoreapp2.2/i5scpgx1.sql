CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE TABLE "Topic" (
    "Id" uuid NOT NULL,
    "Name" text NULL,
    CONSTRAINT "PK_Topic" PRIMARY KEY ("Id")
);

CREATE TABLE "User" (
    "Id" uuid NOT NULL,
    "Name" text NULL,
    "Birthdate" text NULL,
    "Email" text NULL,
    "Senha" text NULL,
    CONSTRAINT "PK_User" PRIMARY KEY ("Id")
);

CREATE TABLE "Publications" (
    "Id" uuid NOT NULL,
    "AutorId" uuid NULL,
    "Title" text NULL,
    "Content" text NULL,
    "DateCreated" timestamp without time zone NOT NULL,
    "TopicId" uuid NULL,
    CONSTRAINT "PK_Publications" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Publications_User_AutorId" FOREIGN KEY ("AutorId") REFERENCES "User" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_Publications_Topic_TopicId" FOREIGN KEY ("TopicId") REFERENCES "Topic" ("Id") ON DELETE RESTRICT
);

CREATE TABLE "Comment" (
    "Id" uuid NOT NULL,
    "AutorId" uuid NULL,
    "Content" text NULL,
    "PublicationId" uuid NULL,
    CONSTRAINT "PK_Comment" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Comment_User_AutorId" FOREIGN KEY ("AutorId") REFERENCES "User" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_Comment_Publications_PublicationId" FOREIGN KEY ("PublicationId") REFERENCES "Publications" ("Id") ON DELETE RESTRICT
);

CREATE INDEX "IX_Comment_AutorId" ON "Comment" ("AutorId");

CREATE INDEX "IX_Comment_PublicationId" ON "Comment" ("PublicationId");

CREATE INDEX "IX_Publications_AutorId" ON "Publications" ("AutorId");

CREATE INDEX "IX_Publications_TopicId" ON "Publications" ("TopicId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191013024742_Inicial', '2.2.6-servicing-10079');

