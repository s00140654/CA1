var ViewModel = function () {
    var self = this;
    self.matches = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();

    self.getMatchDetail = function (item) {
        ajaxHelper(matchesUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }


    var matchesUri = '/api/matches/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllMatches() {
        ajaxHelper(matchesUri, 'GET').done(function (data) {
            self.matches(data);
        });
    }

    // Fetch the initial data.
    getAllMatches();

    self.fixtures = ko.observableArray();
    self.newMatch = {
        Fixture: ko.observable(),
        MatchTitle: ko.observable(),
        KickOff: ko.observable(),
        HomeTeam: ko.observable(),
        HomePrice: ko.observable(),
        AwayTeam: ko.observable(),
        AwayPrice: ko.observable(),
        Draw: ko.observable(),
        DrawPrice: ko.observable()
    }

    var fixturesUri = '/api/fixtures/';

    function getFixtures() {
        ajaxHelper(fixturesUri, 'GET').done(function (data) {
            self.fixtures(data);
        });
    }

    self.addMatch = function (formElement) {
        var match = {
            FixtureId: self.newMatch.Fixture().Id,
            MatchTitle: self.newMatch.MatchTitle(),
            KickOff: self.newMatch.KickOff(),
            HomeTeam: self.newMatch.HomeTeam(),
            HomePrice: self.newMatch.HomePrice(),
            AwayTeam: self.newMatch.AwayTeam(),
            AwayPrice: self.newMatch.AwayPrice(),
            Draw: self.newMatch.Draw(),
            DrawPrice: self.newMatch.DrawPrice()

            
        };

        ajaxHelper(matchesUri, 'POST', match).done(function (item) {
            self.matches.push(item);
        });
    }

    getFixtures();
    getAllMatches();

};

ko.applyBindings(new ViewModel());
