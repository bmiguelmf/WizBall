﻿(function (window, document, $) {
    $(document).on('init.dt', function (e, dtSettings) {
        if (e.namespace !== 'dt') {
            return;
        }

        var options = dtSettings.oInit.conditionalPaging || $.fn.dataTable.defaults.conditionalPaging;

        if ($.isPlainObject(options) || options === true) {
            var config = $.isPlainObject(options) ? options : {},
                api = new $.fn.dataTable.Api(dtSettings),
                speed = 'slow',
                conditionalPaging = function (e) {
                    var $paging = $(api.table().container()).find('div.dataTables_paginate'),
                        pages = api.page.info().pages;

                    if (e instanceof $.Event) {
                        if (pages <= 1) {
                            if (config.style === 'fade') {
                                $paging.stop().fadeTo(speed, 0);
                            }
                            else {
                                $paging.css('visibility', 'hidden');
                            }
                        }
                        else {
                            if (config.style === 'fade') {
                                $paging.stop().fadeTo(speed, 1);
                            }
                            else {
                                $paging.css('visibility', '');
                            }
                        }
                    }
                    else if (pages <= 1) {
                        if (config.style === 'fade') {
                            $paging.css('opacity', 0);
                        }
                        else {
                            $paging.css('visibility', 'hidden');
                        }
                    }
                };

            if (config.speed !== undefined) {
                speed = config.speed;
            }

            conditionalPaging();

            api.on('draw.dt', conditionalPaging);
        }
    });
})(window, document, jQuery);