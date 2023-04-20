mergeInto(LibraryManager.library, {

	SaveExtern: function(date) {
    	var dateString = UTF8ToString(date);
    	var myobj = JSON.parse(dateString);
    	player.setData(myobj);
  	},

  	LoadExtern: function(){
    	player.getData().then(_date => {
        	const myJSON = JSON.stringify(_date);
        	myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
    	});
 	},

 	SetToLeaderboard : function(value){
    	ysdk.getLeaderboards()
      	.then(lb => {
        lb.setLeaderboardScore('Top', value);
      });
  	},

  GetLang: function () {
    var lang = ysdk.environment.i18n.lang;
    var bufferSize = lengthBytesUTF8(lang) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(lang, buffer, bufferSize);
    return buffer;
    },

    ShowAdv : function(){
        myGameInstance.SendMessage('Progress', 'MuteAudio');
        ysdk.adv.showFullscreenAdv({
          callbacks: {
          onClose: function(wasShown) {
            console.log("------------- closed --------------");
            myGameInstance.SendMessage('Progress', 'PlayAudio');
            // some action after close
          },
          onError: function(error) {
            // some action on error
          }
        }
        })
    },

    AddCoinsExtern : function(value){
        ysdk.adv.showRewardedVideo({
          callbacks: {
          onOpen: () => {
            console.log('Video ad open.');
        },
          onRewarded: () => {
            console.log('Rewarded!');
            myGameInstance.SendMessage("CoinManager", "AddCoins", value);
        },
          onClose: () => {
            console.log('Video ad closed.');
        }, 
          onError: (e) => {
            console.log('Error while open video ad:', e);
        }
        }
        })
    },
  });