#include "base.h"

struct ISO8583 master[128] = {
/* FIELD  1 */ {0,"BIT MAP,EXTENDED                    ", 16, 0, 0, 0, NULL},
/* FIELD  2 */ {0,"PRIMARY ACCOUNT NUMBER              ", 19, 0, 2, 0, NULL},
/* FIELD  3 */ {0,"PROCESSING CODE                     ",  6, 0, 0, 0, NULL},
/* FIELD  4 */ {0,"AMOUNT, TRANSACTION                 ", 12, 0, 0, 0, NULL},
/* FIELD  5 */ {0,"AMOUNT, SETTLEMENT                  ", 12, 0, 0, 0, NULL},
/* FIELD  6 */ {0,"AMOUNT, CARDHOLDER BILLING          ", 12, 0, 0, 0, NULL},
/* FIELD  7 */ {0,"TRANSACTION DATE AND TIME           ", 10, 0, 0, 0, NULL},
/* FIELD  8 */ {0,"AMOUNT, CARDHOLDER BILLING FEE      ",  8, 0, 0, 0, NULL},
/* FIELD  9 */ {0,"CONVERSION RATE,SETTLEMENT          ",  8, 0, 0, 0, NULL},
/* FIELD 10 */ {0,"CONVERSION RATE,CARDHOLDER BILLING  ",  8, 0, 0, 0, NULL},
/* FIELD 11 */ {0,"SYSTEM TRACE AUDIT NUMBER           ",  6, 0, 0, 0, NULL},
/* FIELD 12 */ {0,"TIME, LOCAL TRANSACTION             ",  6, 0, 0, 0, NULL},
/* FIELD 13 */ {0,"DATE, LOCAL TRANSACTION             ",  4, 0, 0, 0, NULL},
/* FIELD 14 */ {0,"DATE, EXPIRATION                    ",  4, 0, 0, 0, NULL},
/* FIELD 15 */ {0,"DATE, SETTLEMENT                    ",  4, 0, 0, 0, NULL},
/* FIELD 16 */ {0,"DATE, CONVERSION                    ",  4, 0, 0, 0, NULL},
/* FIELD 17 */ {0,"DATE, CAPTURE                       ",  4, 0, 0, 0, NULL},
/* FIELD 18 */ {0,"MERCHANT'S TYPE                     ",  4, 0, 0, 0, NULL},
/* FIELD 19 */ {0,"ACQUIRING INSTITUTION COUNTRY CODE  ",  3, 0, 0, 0, NULL},
/* FIELD 20 */ {0,"PRIM. ACCNT. NO. EXT.,COUNTRY CODE  ",  3, 0, 0, 0, NULL},
/* FIELD 21 */ {0,"FORWARDING INSTITUTION COUNTRY CODE ",  3, 0, 0, 0, NULL},
/* FIELD 22 */ {0,"POINT OF SERVICE ENTRY MODE         ",  3, 0, 0, 0, NULL},
/* FIELD 23 */ {0,"CARD SEQUENCE NUMBER                ",  3, 0, 0, 0, NULL},
/* FIELD 24 */ {0,"NETWORK INTERNATIONAL IDENTIFIER    ",  3, 0, 0, 0, NULL},
/* FIELD 25 */ {0,"POINT OF SERVICE CONDITION CODE     ",  2, 0, 0, 0, NULL},
/* FIELD 26 */ {0,"POINT OF SERVICE PIN CAPTURE CODE   ",  2, 0, 0, 0, NULL},
/* FIELD 27 */ {0,"AUTH IDENTIFICATION RESPONSE LENGTH ",  1, 0, 0, 0, NULL},
/* FIELD 28 */ {0,"AMOUNT,TRANSACTION FEE              ",  9, 0, 0, 0, NULL},
/* FIELD 29 */ {0,"AMOUNT,SETTLEMENT FEE               ",  9, 0, 0, 0, NULL},
/* FIELD 30 */ {0,"AMOUNT,TRANSACTION PROCESSING FEE   ",  9, 0, 0, 0, NULL},
/* FIELD 31 */ {0,"AMOUNT,SETTLEMENT PROCESSING FEE    ",  9, 0, 0, 0, NULL},
/* FIELD 32 */ {0,"ACOUIRING INSTITUTION ID. CODE      ", 11, 0, 2, 0, NULL},
/* FIELD 33 */ {0,"FORWARDING INSTITUTION ID. CODE     ", 11, 0, 2, 0, NULL},
/* FIELD 34 */ {0,"PRIMARY ACCOUNT NUMBER,EXTENDED     ", 28, 0, 2, 0, NULL},
/* FIELD 35 */ {0,"TRACK 2 DATA                        ", 37, 0, 2, 0, NULL},
/* FIELD 36 */ {0,"TRACK 3 DATA                        ",104, 0, 3, 0, NULL},
/* FIELD 37 */ {0,"RETRIEVAL REFERENCE NUMBER          ", 12, 0, 0, 0, NULL},
/* FIELD 38 */ {0,"AUTH. IDENTIFICATION RESPONSE       ",  6, 0, 0, 0, NULL},
/* FIELD 39 */ {0,"RESPONSE CODE                       ",  2, 0, 0, 0, NULL},
/* FIELD 40 */ {0,"SERVICE RESTRICTION CODE            ",  3, 0, 0, 0, NULL},
/* FIELD 41 */ {0,"SERVICE CODE                        ",  8, 0, 0, 0, NULL},
/* FIELD 42 */ {0,"CARD ACCEPTOR IDENTIFICATION CODE   ", 15, 0, 0, 0, NULL},
/* FIELD 43 */ {0,"CARD ACCEPTOR NAME/LOCATION         ", 40, 0, 0, 0, NULL},
/* FIELD 44 */ {0,"ADDITIONAL RESPONSE DATA            ", 25, 0, 2, 0, NULL},
/* FIELD 45 */ {0,"TRACK 1 DATA                        ", 76, 0, 2, 0, NULL},
/* FIELD 46 */ {0,"ADDITIONAL DATA --- ISO             ",999, 0, 3, 0, NULL},
/* FIELD 47 */ {0,"ADDITIONAL DATA --- NATIONAL        ",999, 0, 3, 0, NULL},
/* FIELD 48 */ {0,"MOBILE PHONE NUMBER                 ",999, 0, 3, 0, NULL},
/* FIELD 49 */ {0,"ORIGINAL RRN                        ",  3, 0, 0, 0, NULL},
/* FIELD 50 */ {0,"MONTH TO BATCH ENQUIRE              ",  3, 0, 0, 0, NULL},
/* FIELD 51 */ {0,"CURRENCY CODE,CARDHOLDER BILLING    ",  3, 0, 0, 0, NULL},
/* FIELD 52 */ {0,"PERSONAL IDENTIFICATION NUMBER DATA ",  8, 0, 0, 0, NULL},
/* FIELD 53 */ {0,"SECURITY RELATED CONTROL INFORMATION", 16, 0, 0, 0, NULL},
/* FIELD 54 */ {0,"ADDITIONAL AMOUNTS                  ",120, 0, 3, 0, NULL},
/* FIELD 55 */ {0,"RESERVED ISO                        ",255, 0, 3, 0, NULL},
/* FIELD 56 */ {0,"RESERVED ISO                        ",999, 0, 3, 0, NULL},
/* FIELD 57 */ {0,"RESERVED NATIONAL                   ",999, 0, 3, 0, NULL},
/* FIELD 58 */ {0,"RESERVED NATIONAL                   ",999, 0, 3, 0, NULL},
/* FIELD 59 */ {0,"RESERVED NATIONAL                   ",999, 0, 3, 0, NULL},
/* FIELD 60 */ {0,"MOBILE SERIALS NO                   ", 60, 0, 3, 0, NULL},
/* FIELD 61 */ {0,"RESERVED --- PRIVATE                ", 26, 0, 3, 0, NULL},
/* FIELD 62 */ {0,"RESERVED --- PRIVATE                ", 50, 0, 3, 0, NULL},
/* FIELD 63 */ {0,"RESERVED --- PRIVATE                ", 12, 0, 3, 0, NULL},
/* FIELD 64 */ {0,"MESSAGE AUTHENTICATION CODE FIELD   ",  8, 0, 0, 0, NULL},
/* FIELD 65 */ {0,"BIT MAP,EXTENDED                    ",  8, 0, 0, 0, NULL},
/* FIELD 66 */ {0,"PRIMARY ACCOUNT NUMBER              ",  1, 0, 0, 0, NULL},
/* FIELD 67 */ {0,"PROCESSING CODE                     ",  2, 0, 0, 0, NULL},
/* FIELD 68 */ {0,"AMOUNT, TRANSACTION                 ",  3, 0, 0, 0, NULL},
/* FIELD 69 */ {0,"AMOUNT, SETTLEMENT                  ",  3, 0, 0, 0, NULL},
/* FIELD 70 */ {0,"AMOUNT, CARDHOLDER BILLING          ",  3, 0, 0, 0, NULL},
/* FIELD 71 */ {0,"TRANSACTION DATE AND TIME           ",  4, 0, 0, 0, NULL},
/* FIELD 72 */ {0,"AMOUNT, CARDHOLDER BILLING FEE      ",  4, 0, 0, 0, NULL},
/* FIELD 73 */ {0,"CONVERSION RATE,SETTLEMENT          ",  6, 0, 0, 0, NULL},
/* FIELD 74 */ {0,"CONVERSION RATE,CARDHOLDER BILLING  ", 10, 0, 0, 0, NULL},
/* FIELD 75 */ {0,"SYSTEM TRACE AUDIT NUMBER           ", 10, 0, 0, 0, NULL},
/* FIELD 76 */ {0,"TIME, LOCAL TRANSACTION             ", 10, 0, 0, 0, NULL},
/* FIELD 77 */ {0,"DATE, LOCAL TRANSACTION             ", 10, 0, 0, 0, NULL},
/* FIELD 78 */ {0,"DATE, EXPIRATION                    ", 10, 0, 0, 0, NULL},
/* FIELD 79 */ {0,"DATE, SETTLEMENT                    ", 10, 0, 0, 0, NULL},
/* FIELD 80 */ {0,"DATE, CONVERSION                    ", 10, 0, 0, 0, NULL},
/* FIELD 81 */ {0,"DATE, CAPTURE                       ", 10, 0, 0, 0, NULL},
/* FIELD 82 */ {0,"MERCHANT'S TYPE                     ", 12, 0, 0, 0, NULL},
/* FIELD 83 */ {0,"ACQUIRING INSTITUTION COUNTRY CODE  ", 12, 0, 0, 0, NULL},
/* FIELD 84 */ {0,"PRIM. ACCNT. NO. EXT.,COUNTRY CODE  ", 12, 0, 0, 0, NULL},
/* FIELD 85 */ {0,"FORWARDING INSTITUTION COUNTRY CODE ", 12, 0, 0, 0, NULL},
/* FIELD 86 */ {0,"POINT OF SERVICE ENTRY MODE         ", 16, 0, 0, 0, NULL},
/* FIELD 87 */ {0,"CARD SEQUENCE NUMBER                ", 16, 0, 0, 0, NULL},
/* FIELD 88 */ {0,"NETWORK INTERNATIONAL IDENTIFIER    ", 16, 0, 0, 0, NULL},
/* FIELD 89 */ {0,"POINT OF SERVICE CONDITION CODE     ", 16, 0, 0, 0, NULL},
/* FIELD 90 */ {0,"POINT OF SERVICE PIN CAPTURE CODE   ", 42, 0, 0, 0, NULL},
/* FIELD 91 */ {0,"AUTH IDENTIFICATION RESPONSE LENGTH ",  1, 0, 0, 0, NULL},
/* FIELD 92 */ {0,"AMOUNT,TRANSACTION FEE              ",  2, 0, 0, 0, NULL},
/* FIELD 93 */ {0,"AMOUNT,SETTLEMENT FEE               ",  5, 0, 0, 0, NULL},
/* FIELD 94 */ {0,"AMOUNT,TRANSACTION PROCESSING FEE   ",  7, 0, 0, 0, NULL},
/* FIELD 95 */ {0,"AMOUNT,SETTLEMENT PROCESSING FEE    ", 42, 0, 0, 0, NULL},
/* FIELD 96 */ {0,"ACOUIRING INSTITUTION ID. CODE      ",  8, 0, 0, 0, NULL},
/* FIELD 97 */ {0,"FORWARDING INSTITUTION ID. CODE     ", 17, 0, 0, 0, NULL},
/* FIELD 98 */ {0,"PRIMARY ACCOUNT NUMBER,EXTENDED     ", 25, 0, 0, 0, NULL},
/* FIELD 99 */ {0,"TRACK 2 DATA                        ", 11, 0, 2, 0, NULL},
/* FIELD 100*/ {0,"TRACK 3 DATA                        ", 11, 0, 2, 0, NULL},
/* FIELD 101*/ {0,"RETRIEVAL REFERENCE NUMBER          ", 17, 0, 2, 0, NULL},
/* FIELD 102*/ {0,"AUTH. IDENTIFICATION RESPONSE       ", 28, 0, 2, 0, NULL},
/* FIELD 103*/ {0,"RESPONSE CODE                       ", 28, 0, 2, 0, NULL},
/* FIELD 104*/ {0,"SERVICE RESTRICTION CODE            ",100, 0, 3, 0, NULL},
/* FIELD 105*/ {0,"OPERATOR ID                         ",999, 0, 3, 0, NULL},
/* FIELD 106*/ {0,"OPERATOR PIN                        ",999, 0, 3, 0, NULL},
/* FIELD 107*/ {0,"OPERATOR NEW PIN                    ",999, 0, 3, 0, NULL},
/* FIELD 108*/ {0,"ADDITIONAL RESPONSE DATA            ",999, 0, 3, 0, NULL},
/* FIELD 109*/ {0,"TRACK 1 DATA                        ",999, 0, 3, 0, NULL},
/* FIELD 110*/ {0,"ADDITIONAL DATA --- ISO             ",999, 0, 3, 0, NULL},
/* FIELD 111*/ {0,"ADDITIONAL DATA --- NATIONAL        ",999, 0, 3, 0, NULL},
/* FIELD 112*/ {0,"ADDITIONAL DATA --- PRIVATE         ",100, 0, 3, 0, NULL},
/* FIELD 113*/ {0,"CURRENCY CODE,TRANSACTION           ",999, 0, 3, 0, NULL},
/* FIELD 114*/ {0,"CURRENCY CODE,SETTLEMENT            ",999, 0, 3, 0, NULL},
/* FIELD 115*/ {0,"CURRENCY CODE,CARDHOLDER BILLING    ",999, 0, 3, 0, NULL},
/* FIELD 116*/ {0,"PERSONAL IDENTIFICATION NUMBER DATA ",999, 0, 3, 0, NULL},
/* FIELD 117*/ {0,"SECURITY RELATED CONTROL INFORMATION",999, 0, 3, 0, NULL},
/* FIELD 118*/ {0,"ADDITIONAL AMOUNTS                  ",999, 0, 3, 0, NULL},
/* FIELD 119*/ {0,"RESERVED ISO                        ",999, 0, 3, 0, NULL},
/* FIELD 120*/ {0,"RESERVED ISO                        ",999, 0, 3, 0, NULL},
/* FIELD 121*/ {0,"RESERVED NATIONAL                   ", 11, 0, 3, 0, NULL},
/* FIELD 122*/ {0,"RESERVED NATIONAL                   ",999, 0, 3, 0, NULL},
/* FIELD 123*/ {0,"RESERVED NATIONAL                   ",999, 0, 3, 0, NULL},
/* FIELD 124*/ {0,"RESERVED --- PRIVATE                ",999, 0, 3, 0, NULL},
/* FIELD 125*/ {0,"RESERVED --- PRIVATE                ",999, 0, 3, 0, NULL},
/* FIELD 126*/ {0,"RESERVED --- PRIVATE                ",999, 0, 3, 0, NULL},
/* FIELD 127*/ {0,"RESERVED --- PRIVATE                ", 50, 0, 3, 0, NULL},
/* FIELD 128*/ {0,"MESSAGE AUTHENTICATION CODE FIELD   ",  8, 0, 0, 0, NULL}
};

struct ISO8583 visa[128] = {
/* FIELD  1 */ {0,"Bitmap,Secondary                    ", 16, 0, 0, 0, NULL},
/* FIELD  2 */ {0,"Primary Acct Nbr                    ", 19, 1, 2, 0, NULL},
/* FIELD  3 */ {0,"Processing Code                     ",  6, 1, 0, 0, NULL},
/* FIELD  4 */ {0,"Amt,Trans                           ", 12, 1, 0, 0, NULL},
/* FIELD  5 */ {0,"Amt,Settlmt                         ", 12, 1, 0, 0, NULL},
/* FIELD  6 */ {0,"Amt,Cdhldr Billing                  ", 12, 1, 0, 0, NULL},
/* FIELD  7 */ {0,"Transmsn Date/time                  ", 10, 1, 0, 0, NULL},
/* FIELD  8 */ {0,"                                    ",  8, 1, 0, 0, NULL},
/* FIELD  9 */ {0,"Conv Rate,settlmt                   ",  8, 1, 0, 0, NULL},
/* FIELD 10 */ {0,"Conv Rate,Cdhldr Billing            ",  8, 1, 0, 0, NULL},
/* FIELD 11 */ {0,"Sys Trace Audit Nbr                 ",  6, 1, 0, 0, NULL},
/* FIELD 12 */ {0,"Time,Local Trans                    ",  6, 1, 0, 0, NULL},
/* FIELD 13 */ {0,"Date,Local Trans                    ",  4, 1, 0, 0, NULL},
/* FIELD 14 */ {0,"Date,Expr                           ",  4, 1, 0, 0, NULL},
/* FIELD 15 */ {0,"Date,Settlmt                        ",  4, 1, 0, 0, NULL},
/* FIELD 16 */ {0,"Date,Conv                           ",  4, 1, 0, 0, NULL},
/* FIELD 17 */ {0,"                                    ",  4, 1, 0, 0, NULL},
/* FIELD 18 */ {0,"Mchnt Type                          ",  4, 1, 0, 0, NULL},
/* FIELD 19 */ {0,"Acqng Inst Cntry Code               ",  3, 1, 0, 0, NULL},
/* FIELD 20 */ {0,"PAN Extnd,Cntry Code                ",  3, 1, 0, 0, NULL},
/* FIELD 21 */ {0,"Fwdng Inst Cntry Code               ",  3, 1, 0, 0, NULL},
/* FIELD 22 */ {0,"POS Entry Mode Code                 ",  4, 1, 0, 0, NULL},
/* FIELD 23 */ {0,"                                    ",  3, 1, 0, 0, NULL},
/* FIELD 24 */ {0,"                                    ",  3, 1, 0, 0, NULL},
/* FIELD 25 */ {0,"POS Cond Code                       ",  2, 1, 0, 0, NULL},
/* FIELD 26 */ {0,"POS PIN Capture Code                ",  2, 1, 0, 0, NULL},
/* FIELD 27 */ {0,"                                    ",  1, 1, 0, 0, NULL},
/* FIELD 28 */ {0,"Amount,Transaction Fee              ",  9, 0, 0, 0, NULL},
/* FIELD 29 */ {0,"                                    ",  9, 0, 0, 0, NULL},
/* FIELD 30 */ {0,"                                    ",  9, 0, 1, 0, NULL},
/* FIELD 31 */ {0,"                                    ",  9, 0, 1, 0, NULL},
/* FIELD 32 */ {0,"Acqng Inst ID Code                  ", 11, 1, 2, 0, NULL},
/* FIELD 33 */ {0,"Fwdng Inst ID Code                  ", 11, 1, 2, 0, NULL},
/* FIELD 34 */ {0,"                                    ", 28, 1, 2, 0, NULL},
/* FIELD 35 */ {0,"Track 2 Data                        ", 37, 1, 2, 0, NULL},
/* FIELD 36 */ {0,"                                    ",104, 1, 3, 0, NULL},
/* FIELD 37 */ {0,"Restreval Ref Nbr                   ", 12, 0, 0, 0, NULL},
/* FIELD 38 */ {0,"Auth ID Resp                        ",  6, 0, 0, 0, NULL},
/* FIELD 39 */ {0,"Resp Code                           ",  2, 0, 0, 0, NULL},
/* FIELD 40 */ {0,"                                    ",  3, 0, 0, 0, NULL},
/* FIELD 41 */ {0,"Card Accptr Termnl ID               ",  8, 0, 0, 0, NULL},
/* FIELD 42 */ {0,"Card Accptr ID Code                 ", 15, 0, 0, 0, NULL},
/* FIELD 43 */ {0,"Card Accptr Name/Loc                ", 40, 0, 0, 0, NULL},
/* FIELD 44 */ {0,"Additional Response Data            ", 25, 0, 2, 0, NULL},
/* FIELD 45 */ {0,"                                    ", 76, 0, 2, 0, NULL},
/* FIELD 46 */ {0,"                                    ",255, 0, 3, 0, NULL},
/* FIELD 47 */ {0,"                                    ",255, 0, 3, 0, NULL},
/* FIELD 48 */ {0,"Additonal Data--Private             ",255, 0, 3, 0, NULL},
/* FIELD 49 */ {0,"Currny Code,Trans                   ",  3, 1, 0, 0, NULL},
/* FIELD 50 */ {0,"Currny Code,Settmt                  ",  3, 1, 0, 0, NULL},
/* FIELD 51 */ {0,"Currny Code,Cdhldr Billing          ",  3, 1, 0, 0, NULL},
/* FIELD 52 */ {0,"PIN Data                            ",  8, 0, 0, 0, NULL},
/* FIELD 53 */ {0,"Security Related Cntrl Info         ", 16, 1, 0, 0, NULL},
/* FIELD 54 */ {0,"Addtnl Amounts                      ", 80, 0, 2, 0, NULL},
/* FIELD 55 */ {0,"                                    ",  0, 0, 3, 0, NULL},
/* FIELD 56 */ {0,"                                    ",  0, 0, 3, 0, NULL},
/* FIELD 57 */ {0,"                                    ",  0, 0, 3, 0, NULL},
/* FIELD 58 */ {0,"                                    ",  0, 0, 3, 0, NULL},
/* FIELD 59 */ {0,"Natl POS Geo Data                   ", 14, 0, 2, 0, NULL},
/* FIELD 60 */ {0,"Addtnl POS Info                     ",  2, 1, 2, 0, NULL},
/* FIELD 61 */ {0,"                                    ", 26, 1, 3, 0, NULL},
/* FIELD 62 */ {0,"CPS Fields Bitmap                   ",  0, 0, 2, 0, NULL},
/* FIELD 63 */ {0,"SMS Private-Use Fields              ", 44, 0, 3, 0, NULL},
/* FIELD 64 */ {0,"                                    ",  8, 0, 0, 0, NULL},
/* FIELD 65 */ {0,"                                    ",  8, 0, 0, 0, NULL},
/* FIELD 66 */ {0,"Sttlmt Code                         ",  1, 1, 0, 0, NULL},
/* FIELD 67 */ {0,"                                    ",  2, 1, 0, 0, NULL},
/* FIELD 68 */ {0,"Rcvg Inst Cntry Code                ",  3, 1, 0, 0, NULL},
/* FIELD 69 */ {0,"Sttlmt Inst Cntry Code              ",  3, 1, 0, 0, NULL},
/* FIELD 70 */ {0,"Ntwk Mngmt Info Code                ",  3, 1, 0, 0, NULL},
/* FIELD 71 */ {0,"                                    ",  4, 1, 0, 0, NULL},
/* FIELD 72 */ {0,"                                    ",  4, 1, 0, 0, NULL},
/* FIELD 73 */ {0,"                                    ",  6, 1, 0, 0, NULL},
/* FIELD 74 */ {0,"Credits,Nbr                         ", 10, 1, 0, 0, NULL},
/* FIELD 75 */ {0,"Credits,Reversal Nbr                ", 10, 1, 0, 0, NULL},
/* FIELD 76 */ {0,"Debits, Nbr                         ", 10, 1, 0, 0, NULL},
/* FIELD 77 */ {0,"Debits,Reversal Nbr                 ", 10, 1, 0, 0, NULL},
/* FIELD 78 */ {0,"                                    ", 10, 1, 0, 0, NULL},
/* FIELD 79 */ {0,"                                    ", 10, 1, 0, 0, NULL},
/* FIELD 80 */ {0,"                                    ", 10, 1, 0, 0, NULL},
/* FIELD 81 */ {0,"                                    ", 10, 1, 0, 0, NULL},
/* FIELD 82 */ {0,"                                    ", 12, 1, 0, 0, NULL},
/* FIELD 83 */ {0,"                                    ", 12, 1, 0, 0, NULL},
/* FIELD 84 */ {0,"                                    ", 12, 1, 0, 0, NULL},
/* FIELD 85 */ {0,"                                    ", 12, 1, 0, 0, NULL},
/* FIELD 86 */ {0,"Credits,Amt                         ", 16, 1, 0, 0, NULL},
/* FIELD 87 */ {0,"Credits,Reversal Amt                ", 16, 1, 0, 0, NULL},
/* FIELD 88 */ {0,"Debits,Amt                          ", 16, 1, 0, 0, NULL},
/* FIELD 89 */ {0,"Debits,Reversal Amt                 ", 16, 1, 0, 0, NULL},
/* FIELD 90 */ {0,"Orig Data Elements                  ", 42, 1, 0, 0, NULL},
/* FIELD 91 */ {0,"                                    ",  1, 0, 0, 0, NULL},
/* FIELD 92 */ {0,"                                    ",  2, 0, 0, 0, NULL},
/* FIELD 93 */ {0,"                                    ",  5, 0, 0, 0, NULL},
/* FIELD 94 */ {0,"                                    ",  7, 0, 0, 0, NULL},
/* FIELD 95 */ {0,"                                    ", 42, 0, 0, 0, NULL},
/* FIELD 96 */ {0,"Msg Security Code                   ", 16, 0, 0, 0, NULL},
/* FIELD 97 */ {0,"Amount,Net Settlmt                  ", 17, 0, 0, 0, NULL},
/* FIELD 98 */ {0,"                                    ", 25, 0, 0, 0, NULL},
/* FIELD 99 */ {0,"Settlmt Inst ID Code                ", 11, 1, 2, 0, NULL},
/* FIELD 100*/ {0,"Rcvg Inst Cntry Code                ", 11, 1, 2, 0, NULL},
/* FIELD 101*/ {0,"                                    ", 17, 0, 2, 0, NULL},
/* FIELD 102*/ {0,"Account Id 1                        ", 28, 0, 2, 0, NULL},
/* FIELD 103*/ {0,"                                    ",  2, 0, 0, 0, NULL},
/* FIELD 104*/ {0,"                                    ",  3, 0, 0, 0, NULL},
/* FIELD 105*/ {0,"                                    ",  6, 0, 0, 0, NULL},
/* FIELD 106*/ {0,"                                    ", 10, 0, 3, 0, NULL},
/* FIELD 107*/ {0,"                                    ", 10, 0, 3, 0, NULL},
/* FIELD 108*/ {0,"                                    ", 25, 0, 2, 0, NULL},
/* FIELD 109*/ {0,"                                    ", 76, 0, 2, 0, NULL},
/* FIELD 110*/ {0,"                                    ",  0, 0, 3, 0, NULL},
/* FIELD 111*/ {0,"                                    ",  0, 0, 3, 0, NULL},
/* FIELD 112*/ {0,"                                    ",  0, 0, 3, 0, NULL},
/* FIELD 113*/ {0,"                                    ",  3, 0, 0, 0, NULL},
/* FIELD 114*/ {0,"                                    ",  3, 0, 0, 0, NULL},
/* FIELD 115*/ {0,"Addtnl Trace Data1                  ", 24, 0, 2, 0, NULL},
/* FIELD 116*/ {0,"                                    ",  8, 0, 0, 0, NULL},
/* FIELD 117*/ {0,"                                    ", 16, 0, 0, 0, NULL},
/* FIELD 118*/ {0,"                                    ",120, 0, 3, 0, NULL},
/* FIELD 119*/ {0,"Settlmt Svc Data                    ", 15, 0, 2, 0, NULL},
/* FIELD 120*/ {0,"                                    ",999, 1, 3, 0, NULL},
/* FIELD 121*/ {0,"                                    ",  0, 0, 3, 0, NULL},
/* FIELD 122*/ {0,"                                    ",  0, 0, 3, 0, NULL},
/* FIELD 123*/ {0,"                                    ",  0, 0, 3, 0, NULL},
/* FIELD 124*/ {0,"                                    ",  0, 0, 3, 0, NULL},
/* FIELD 125*/ {0,"                                    ",999, 0, 3, 0, NULL},
/* FIELD 126*/ {0,"                                    ",  0, 0, 3, 0, NULL},
/* FIELD 127*/ {0,"                                    ",  0, 0, 3, 0, NULL},
/* FIELD 128*/ {0,"                                    ",  8, 0, 0, 0, NULL}
};
			
int unpack_master_8583(char *buf)
{
	int i,j,k,l,t,bit;
	int buflen;
	char st_len[4];
	char ch;
	char bitmap[32];
	
	memset(bitmap, 0, sizeof(bitmap));
		
	for(i=0;i<128;i++)
//		if(master[i].data != NULL){
		if(master[i].bit_flag == 1){
			free(master[i].data);
			master[i].data = NULL;
		}

	if(buf[0] >= '8'){
		memcpy(bitmap, buf, 32);
		bitmap[32] = '\0';
	}
	else{
		memcpy(bitmap, buf, 16);
		bitmap[16] = '\0';
	}
	buf += 16;
	
	for (i=0;i<strlen(bitmap);i++)               		 /* 遍历BITMAP每个字节 */
		for (bit=0x08,j=0;j<4;j++,bit/=2) {          	 /* 每个字节表示四个域 */
			k = i * 4 + j ;                  	 /* 域下标 */
			if(bitmap[i] > 0x40) 
				ch = bitmap[i] -7;
			else
				ch = bitmap[i];
			if  ((ch & bit) == 0x00){
				master[k].bit_flag = 0;		/*该域不存在*/		 
				continue;
			}
			else 
				master[k].bit_flag = 1;     	/*该域存在*/
			if(master[k].variable_flag > 0){
				memset(st_len, 0, sizeof(st_len));
				strncpy(st_len, buf, (master[k].variable_flag));		/*取可变长域的值的实际长度*/
				buf  = buf + (master[k].variable_flag);
				master[k].length = atoi(st_len);
			}
				if(master[k].attribute)
					master[k].length_in_byte = (master[k].length + 1)/2; /* BCD码格式,每个字节两个值*/
				else
					master[k].length_in_byte = master[k].length;	/* ASCII码格式,每个字节一个值*/	

			master[k].data = (char *)malloc(master[k].length_in_byte * sizeof(char)+1);	
			memcpy(master[k].data,buf,master[k].length_in_byte); /* 拷贝该域的值 */
			master[k].data[master[k].length_in_byte]=0;
//			printf("[%d][%s]\n",k,master[k].data);
			buf += master[k].length_in_byte;		 /* 指向下一个域 */
		}                
	return TRUE;
}
int pack_master_8583(char *buf8583)
{
	int i;
	int offset = 0;
	char buf[2048];
	char *bitmap;
	char *head;
	char len[10];
	char tmpstr[2];
	int bit = 0;
	int longflat = 0;
	
	memset(buf, 0, sizeof(buf));
	bitmap = (char *)malloc(sizeof(char)*33);
	memset(bitmap, 0, 33);
	memset(tmpstr, 0, sizeof(tmpstr));
	
	head = bitmap;	
	for(i=1;i<128;i++){
		if(master[i].bit_flag == 1){
			if(master[i].variable_flag >0){
				memset(len, 0, sizeof(len));
				sprintf(len, "%%0%dd%%s", master[i].variable_flag);
				sprintf(buf+offset, len, master[i].length_in_byte,master[i].data);
				offset += master[i].length_in_byte + master[i].variable_flag;
			}
			else{
				memcpy(buf+offset,master[i].data, master[i].length_in_byte);
				offset += master[i].length_in_byte;
			}
			switch((i+1)%4){
				case 1:
					bit += 8;
					break;
				case 2:
					bit += 4;
					break;
				case 3:
					bit += 2;
					break;
				case 0:
					bit += 1;
					break;
			}
		}
		if((i+1)%4 == 0) {
			sprintf(bitmap, "%X", bit);
			bitmap ++;
			bit = 0;
		}
	}
	bitmap = head;
	if(memcmp(bitmap+16, "0000000000000000", 16) == 0){
		memcpy(buf8583, bitmap, 16);
		memcpy(buf8583+16, buf, offset);
		offset += 16;
	}
	else{
		memcpy(tmpstr, bitmap, 1);
		i = atoi(tmpstr) + 8;
		sprintf(tmpstr, "%X", i);
		memcpy(bitmap, tmpstr, 1);
		memcpy(buf8583, bitmap, 32);
		memcpy(buf8583+32, buf, offset);
		offset += 32;
	}
	free(bitmap);
	
	return offset;
}
int put_master_value(int fieldno, char *data, int len)
{
	master[fieldno-1].bit_flag = 1;
	master[fieldno-1].length_in_byte = len;
	master[fieldno-1].data = (char *)malloc(len+1);
	memset(master[fieldno-1].data, 0, len+1);
	memcpy(master[fieldno-1].data, data, len);
	master[fieldno-1].data[len] = '\0';
	
	return TRUE;
}
int del_master_value(int fieldno)
{
	if(master[fieldno-1].bit_flag == 1){
		master[fieldno-1].bit_flag = 0;
		free(master[fieldno-1].data);
		master[fieldno-1].data = NULL;
	}
	return TRUE;
}

int del_visa_value(int fieldno)
{
	if(visa[fieldno-1].bit_flag == 1){
		visa[fieldno-1].bit_flag = 0;
		free(visa[fieldno-1].data);
		visa[fieldno-1].data = NULL;
	}
	return TRUE;
}
int init_master_8583()
{
	int i;
	
	for(i=0;i<128;i++)
		if(master[i].data != NULL){
			free(master[i].data);
			master[i].data = NULL;
			master[i].bit_flag = 0;
		}
}	
int debug_master_8583()
{
	int i;
	printf("<========debug master 8583 package begin========>\n");	
	for(i=0;i<128;i++)
		if(master[i].bit_flag == 1)
			printf("%-3d\t[%s]\n",i+1,master[i].data);
	printf("<=========debug master 8583 package end=========>\n");	
	return TRUE;
} 
int unpack_visa_8583(char *buf)
{
	int i,j,k,l,t,bit;
	int buflen;
	char st_len[4];
	char ch;
	char bitmap[32];
	
	memset(bitmap, 0, sizeof(bitmap));
		
	for(i=0;i<128;i++)
//		if(visa[i].data != NULL){
		if(visa[i].bit_flag == 1){
			free(visa[i].data);
			visa[i].data = NULL;
		}

	if(buf[0] >= '8'){
		memcpy(bitmap, buf, 32);
		bitmap[32] = '\0';
	}
	else{
		memcpy(bitmap, buf, 16);
		bitmap[16] = '\0';
	}
	buf += 16;

	for (i=0;i<strlen(bitmap);i++)               		 /* 遍历BITMAP每个字节 */
		for (bit=0x08,j=0;j<4;j++,bit/=2) {          	 /* 每个字节表示四个域 */
			k = i * 4 + j ;                  	 /* 域下标 */
			if(bitmap[i] > 0x40) 
				ch = bitmap[i] -7;
			else
				ch = bitmap[i];
			if  ((ch & bit) == 0x00){
				visa[k].bit_flag = 0;		/*该域不存在*/		 
				continue;
			}
			else 
				visa[k].bit_flag = 1;     	/*该域存在*/

			if(visa[k].variable_flag > 0){
				memset(st_len, 0, sizeof(st_len));
				strncpy(st_len, buf, (visa[k].variable_flag));		/*取可变长域的值的实际长度*/
				buf  = buf + (visa[k].variable_flag);
				visa[k].length = atoi(st_len);
			}
	//			if(visa[k].attribute)
	//				visa[k].length_in_byte = (visa[k].length + 1)/2; /* BCD码格式,每个字节两个值*/
	//			else
					visa[k].length_in_byte = visa[k].length;	/* ASCII码格式,每个字节一个值*/	

			visa[k].data = (char *)malloc(visa[k].length_in_byte * sizeof(char)+1);	
			memcpy(visa[k].data,buf,visa[k].length_in_byte); /* 拷贝该域的值 */
			visa[k].data[visa[k].length_in_byte]=0;
	//		printf("[%d][%d][%s]\n",k+1,visa[k].length_in_byte,visa[k].data);
			buf += visa[k].length_in_byte;		 /* 指向下一个域 */
		}                
	return TRUE;
}
int pack_visa_8583(char *buf8583)
{
	int i;
	int offset = 0;
	char buf[2048];
	char *bitmap;
	char *head;
	char len[10];
	char tmpstr[2];
	int bit = 0;
	int longflat = 0;
	int visalen = 0;
	char ch;
	
	memset(buf, 0, sizeof(buf));
	bitmap = (char *)malloc(sizeof(char)*33);
	memset(bitmap, 0, 33);
	memset(tmpstr, 0, sizeof(tmpstr));
	
	head = bitmap;	
	for(i=1;i<128;i++){
		if(visa[i].bit_flag == 1){
			if(visa[i].variable_flag >0){
				memset(len, 0, sizeof(len));
				sprintf(len, "%%0%dd%%s", visa[i].variable_flag);
				sprintf(buf+offset, len, visa[i].length_in_byte,visa[i].data);
				offset += visa[i].length_in_byte + visa[i].variable_flag;
				if(i == 61){
					visalen += 1;
					visalen += 8;
					ch = visa[i].data[0];
					if(ch > 0x40) ch -= 7;
					if((ch & 0x08) != 0x00)	
						visalen += 1;
					if((ch & 0x04) != 0x00)
						visalen += (15+1)/2;
				}
				else if(i == 62){
					visalen += 1;
					visalen += 3;
					ch = visa[i].data[0];
					if(ch > 0x40) ch -= 7;
					if((ch & 0x08) != 0x00)
						visalen += (4+1)/2;
					if((ch & 0x02) != 0x00)
						visalen += (4+1)/2;
					if((ch & 0x01) != 0x00)
						visalen += (4+1)/2;
					ch = visa[i].data[1];
					if(ch > 0x40) ch -= 7;
					if((ch & 0x08) != 0x00)
						visalen += (6+1)/2;
					ch = visa[i].data[3];
					if(ch > 0x40) ch -= 7;
					if((ch & 0x08) != 0x00)
						visalen += (6+1)/2;
					if((ch & 0x04) != 0x00)
						visalen += 36;
					if((ch & 0x02) != 0x00)
						visalen += 9;
				}else if(visa[i].attribute == 1) 
					visalen += (visa[i].length_in_byte + 1)/2 + 1;
				else 
					visalen += visa[i].length_in_byte + 1;
			}
			else{
				memcpy(buf+offset,visa[i].data, visa[i].length_in_byte);
				offset += visa[i].length_in_byte;
				if(visa[i].attribute == 1)
					visalen += (visa[i].length_in_byte +1)/2;
				else
					visalen += visa[i].length_in_byte;
			}
			switch((i+1)%4){
				case 1:
					bit += 8;
					break;
				case 2:
					bit += 4;
					break;
				case 3:
					bit += 2;
					break;
				case 0:
					bit += 1;
					break;
			}
		}
		if((i+1)%4 == 0) {
			sprintf(bitmap, "%X", bit);
			bitmap ++;
			bit = 0;
		}
	}
	bitmap = head;
	if(memcmp(bitmap+16, "0000000000000000", 16) == 0){
		memcpy(buf8583, bitmap, 16);
		memcpy(buf8583+16, buf, offset);
		visalen += 8;
	}
	else{
		memcpy(tmpstr, bitmap, 1);
		i = atoi(tmpstr) + 8;
		sprintf(tmpstr, "%X", i);
		memcpy(bitmap, tmpstr, 1);
		memcpy(buf8583, bitmap, 32);
		memcpy(buf8583+32, buf, offset);
		visalen += 16;
	}
	free(bitmap);
	
	return visalen;
}
int init_visa_8583()
{
	int i;
	
	for(i=0;i<128;i++)
		if(visa[i].data != NULL){
			free(visa[i].data);
			visa[i].data = NULL;
			visa[i].bit_flag = 0;
		}
}	
int debug_visa_8583()
{
	int i;

	printf("<========debug visa 8583 package begin========>\n");	
	for(i=0;i<128;i++)
		if(visa[i].bit_flag == 1)
			printf("%-3d\t[%s]\n",i+1,visa[i].data);
	printf("<=========debug visa 8583 package end=========>\n");	
	return TRUE;
} 
int put_visa_value(int fieldno, char *data, int len)
{
	visa[fieldno-1].bit_flag = 1;
	visa[fieldno-1].length_in_byte = len;
	visa[fieldno-1].data = (char *)malloc(len+1);
	memset(visa[fieldno-1].data, 0, len+1);
	memcpy(visa[fieldno-1].data, data, len);
	visa[fieldno-1].data[len] ='\0';
	
	return TRUE;
}
