using Felix.WebService.DAL;
using Felix.WebService.Data.Models.Comment;
using Felix.WebService.Data.Models.Identity;
using Felix.WebService.Data.Models.Movie;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Felix.WebService.Services.Seeds
{
    public class ExampleCommentsDataSeed : IDataSeed
    {
        public Guid Guid => new("A7B7D305-9649-431A-AA77-E346DCE7D854");

        public void SeedData(UnitOfWork unitOfWork)
        {
            Cut cut_1 = unitOfWork.CutRepository.FirstOrDefault(
                filter: x => x.Name.Equals("Example cut 01"));

            Cut cut_2 = unitOfWork.CutRepository.FirstOrDefault(
                filter: x => x.Name.Equals("Example cut 02"));

            Shot exampleShot_1_v1 = unitOfWork.ShotRepository.FirstOrDefault(
                filter: x => x.Name.Equals("shot-1"));

            Shot exampleShot_1_v2 = unitOfWork.ShotRepository.FirstOrDefault(
                filter: x => x.Name.Equals("shot-1-v2"));

            Shot exampleShot_4_v1 = unitOfWork.ShotRepository.FirstOrDefault(
                filter: x => x.Name.Equals("shot-4"));

            Shot exampleShot_4_v2 = unitOfWork.ShotRepository.FirstOrDefault(
                filter: x => x.Name.Equals("shot-4-v2"));

            ShotCutRel exampleShotCutRel_1 = unitOfWork.ShotCutRelRepository.FirstOrDefault(
                filter: x => x.ShotId.Equals(exampleShot_1_v1.Id) && x.CutId.Equals(cut_1.Id));

            ShotCutRel exampleShotCutRel_2 = unitOfWork.ShotCutRelRepository.FirstOrDefault(
                filter: x => x.ShotId.Equals(exampleShot_1_v2.Id) && x.CutId.Equals(cut_2.Id));

            ShotCutRel exampleShotCutRel_3 = unitOfWork.ShotCutRelRepository.FirstOrDefault(
                filter: x => x.ShotId.Equals(exampleShot_4_v1.Id) && x.CutId.Equals(cut_1.Id));

            ShotCutRel exampleShotCutRel_4 = unitOfWork.ShotCutRelRepository.FirstOrDefault(
                filter: x => x.ShotId.Equals(exampleShot_4_v2.Id) && x.CutId.Equals(cut_2.Id));

            User artDirector_1 = unitOfWork.UserRepository.FirstOrDefault(
                filter: x => x.UserName == "test.jozsi");

            User artDirector_2 = unitOfWork.UserRepository.FirstOrDefault(
                filter: x => x.UserName == "test.feco");

            User artist_1 = unitOfWork.UserRepository.FirstOrDefault(
                filter: x => x.UserName == "test.bela");

            User artist_2 = unitOfWork.UserRepository.FirstOrDefault(
                filter: x => x.UserName == "test.gabor");

            List<Comment> comments = new()
            {
                new()
                {
                    Text = "Csak egy kis részen törjön az üveg és szóródjanak az üvegcserepek, ahol becsapódnak! Amúgy az animáció jó lesz!",
                    StartFrame = 25,
                    EndFrame = 32,
                    CreatedAt = DateTime.Now.AddDays(-55).AddHours(-12).AddMinutes(32),
                    CreatedBy = artDirector_1,
                    Priority = Enums.CommentPriorityEnum.Medium,
                    ShotCutRel = exampleShotCutRel_1
                },
                new()
                {
                    Text = "Üvegek hozzáadva. Ennyi elég lesz vagy adjunk még hozzá?",
                    StartFrame = 25,
                    EndFrame = 32,
                    CreatedAt = DateTime.Now.AddDays(-33).AddHours(-6).AddMinutes(-65),
                    CreatedBy = artist_1,
                    Priority = Enums.CommentPriorityEnum.Medium,
                    ShotCutRel = exampleShotCutRel_2
                },
                new()
                {
                    Text = "Nem, nagyon szuper lett, köszönöm!",
                    StartFrame = 25,
                    EndFrame = 32,
                    CreatedAt = DateTime.Now.AddDays(-33).AddHours(-2).AddMinutes(11),
                    CreatedBy = artDirector_1,
                    Priority = Enums.CommentPriorityEnum.Low,
                    ShotCutRel = exampleShotCutRel_2
                },
                new()
                {
                    Text = "A háttérben már legyenek nyitva a portálok, legyen a keretük valamilyen sárga, egyikben valami hegyvidéki kékes tájat kell látnunk, a másikban egy délutáni, sárgás fényű kolostort.",
                    StartFrame = 1,
                    EndFrame = 93,
                    CreatedAt = DateTime.Now.AddDays(-33).AddHours(-32).AddMinutes(53),
                    CreatedBy = artDirector_1,
                    Priority = Enums.CommentPriorityEnum.Medium,
                    ShotCutRel = exampleShotCutRel_3
                },
                new()
                {
                    Text = "Elkészült a véglegesnek szánt jelenet. Ha van rá igény, akkor viszonylag gyorsan cserélhetők a hátterek a portálban.",
                    StartFrame = 1,
                    EndFrame = 93,
                    CreatedAt = DateTime.Now.AddDays(-11).AddHours(-2).AddMinutes(74),
                    CreatedBy = artist_2,
                    Priority = Enums.CommentPriorityEnum.High,
                    ShotCutRel = exampleShotCutRel_4
                },
                new()
                {
                    Text = "Nagyon jók lettek, részemről végleges!",
                    StartFrame = 1,
                    EndFrame = 93,
                    CreatedAt = DateTime.Now.AddDays(-9).AddHours(-3).AddMinutes(1),
                    CreatedBy = artDirector_2,
                    Priority = Enums.CommentPriorityEnum.Medium,
                    ShotCutRel = exampleShotCutRel_4
                },
                new()
                {
                    Text = "Nekem is tetszik!",
                    StartFrame = 1,
                    EndFrame = 93,
                    CreatedAt = DateTime.Now.AddDays(-9).AddHours(-3).AddMinutes(1),
                    CreatedBy = artDirector_1,
                    Priority = Enums.CommentPriorityEnum.Medium,
                    ShotCutRel = exampleShotCutRel_4
                },
                new()
                {
                    Text = "A Wanda Maximoff Chaos Magic-e színe pont jó piros, viszont a végleges változatban kicsivel több lens flare-t szeretnék látni, hogy hangsúlyosabb legyen.",
                    StartFrame = 51,
                    EndFrame = 93,
                    CreatedAt = DateTime.Now.AddDays(-9).AddHours(-3).AddMinutes(1),
                    CreatedBy = artDirector_1,
                    Priority = Enums.CommentPriorityEnum.Medium,
                    ShotCutRel = exampleShotCutRel_4
                },
                new()
                {
                    Text = "Rajta leszek!",
                    StartFrame = 51,
                    EndFrame = 93,
                    CreatedAt = DateTime.Now.AddDays(-7).AddHours(-5).AddMinutes(6),
                    CreatedBy = artist_2,
                    Priority = Enums.CommentPriorityEnum.Medium,
                    ShotCutRel = exampleShotCutRel_4
                }
            };

            unitOfWork.CommentRepository.CreateRange(comments);
        }
    }
}
