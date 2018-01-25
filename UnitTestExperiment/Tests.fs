namespace Crews.Experiment

open System

module Messaging =
    type Envelope<'a> = {
        Id : Guid
        Created : DateTimeOffset
        Item : 'a
    }

    let envelop getId getTime item = {
        Id = Guid.Empty
        Created = DateTimeOffset.MinValue
        Item = item
    }

module MessagingTests =
    open Xunit

    type Silly = { Text : string; Number : int }

    [<Fact>]
    let ``envelop returns the correct result`` () =
        let getId _ = Guid "F485744C-291C-4A84-AF5C-8A5BDAE68658"
        let getTime _ = DateTimeOffset(636524690620321491L, TimeSpan.FromHours -8.)
        let item = { Text = "Chicken"; Number = 1337 }

        let actual = Messaging.envelop getId getTime item

        Assert.Equal(Guid "F485744C-291C-4A84-AF5C-8A5BDAE68658", actual.Id)
        Assert.Equal(DateTimeOffset(636524690620321491L, TimeSpan.FromHours -8.), actual.Created)
        Assert.Equal(item, actual.Item)