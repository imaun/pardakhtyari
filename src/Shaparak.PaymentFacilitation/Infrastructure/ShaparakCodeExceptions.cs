﻿namespace Shaparak.PaymentFacilitation {

    public enum ShaparakCodeExceptions {
        UNDEFINED = -1,
        MANDATORY_FIELD = 5,
        FORMAT_FIELD = 6,
        DUPLICATE_RECORD = 11,
        INVALID_IDENTIFICATION_DATA = 12,
        SYSTEM_EXCEPTION = 13,
        NO_IBANS = 15,
        MASTER_DETAIL_RELATION = 16,
        BAD_DATA = 17,
        CHILD_RECORD_FOUND = 18,
        ERROR_APPLY_SWITCH_RESULT = 25,
        BAD_AGE_RANGE = 29,
        THE_PERSON_IS_DECEASED = 30,
        SEND_SMS_FAILURE = 31,
        INVALID_CERTIFICATE_ISSUE_DATE = 35,
        DUPLICATE_RECORD_NATIONAL_CODE = 36,
        LIMITATION_MERCHANT = 37,
        INVALID_POSTAL_CODE = 39,
        UNABLE_TO_ENQUIRE_IBAN_INFO = 40,
        INVALID_IBAN = 41,
        LENGTH_FIELD = 43,
        OLD_SYSTEM_DATA_EXISTS = 44,
        DUPLICATE_FIELD = 46,
        INVALID_TERMINAL_TYPE_FOR_BUSINESS_TYPE = 47,
        UNKNOWN_IBAN_BANK = 48,
        MERCHANT_NOT_EXISTS = 49,
        INVALID_IBAN_ACCEPTOR = 51,
        DATA_NOT_EXISTS = 52,
        UNCHANGED_DATA= 54,
        DUPLICATE_OLD_ACCEPTOR = 55,
        INVALID_REQUEST = 56,
        DUPLICATE_REQUEST_FOR_ACCEPTOR = 57,
        BAD_DATA_RANGE = 58,
        INVALID_SHOP_FOR_ACCEPTOR = 59,
        INVALID_DATA_TYPE = 60,
        INCONSISTENT_DATA = 61,
        INVALID_PROVINCE_FOR_POSTAL_CODE = 62,
        INVALID_CITY_FOR_POSTAL_CODE = 63,
        PARTIAL_DATA = 64,
        UNCHANGED_IBAN = 65,
        SWITCH_CHANGE_ERROR = 66,
        SHAPARAK_ADMINISTRATION_REJECTION = 67,
        UNABLE_TO_ACTIVATE_PERMANENTLY_DEACTIVATED_TERM = 68,
        UNABLE_TO_MIGRATE_PERMANENTLY_DEACTIVATED_ACCEP = 69,
        ITEM_COUNT_LIMIT_REACHED = 70,
        BLACKLISTED_MERCHANT = 1002,
        DUPLICATE_REQUEST_FOR_TERMINAL = 10000,
        REQUEST_INVALID_FOR_RESPONSE = 10001,
        REQUEST_NOTFOUND_FOR_RESPONSE = 10002,
        DUPLICATE_TERMINAL = 10003,
        NO_TERMINALS = 10004,
        ADMIN_REQUEST_REJECTION = 10008
    }

}
