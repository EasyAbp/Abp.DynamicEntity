(function (factory) {
  if (typeof define === 'function' && define.amd) {
    define(['jquery'], factory);
  } else if (typeof module === 'object' && typeof module.exports === 'object') {
    factory(require('jquery'));
  } else {
    factory(jQuery);
  }
}(function (jQuery) {
  // Danish
  jQuery.timeago.settings.strings = {
    prefixAgo: "for",
    prefixFromNow: "om",
    suffixAgo: "siden",
    suffixFromNow: "",
    seconds: "mindre end et minut",
    minute: "ca. et minut",
    minutes: "%d minutter",
    hour: "ca. en time",
    hours: "ca. %d timer",
    day: "en dag",
    days: "%d dage",
    month: "ca. en måned",
    months: "%d måneder",
    year: "ca. et år",
    years: "%d år"
  };
}));
