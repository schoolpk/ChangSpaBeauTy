
╔══════════════════════════════════════════════════════════════════╗
║          ChangSpaBeauTy – Unit Test Results                     ║
║          NUnit 4.2.2 | .NET 8.0 | 20 Test Cases                ║
╚══════════════════════════════════════════════════════════════════╝

Test Project: ChangSpaBeauTy.Tests
Framework:    NUnit 4.2.2
Runtime:      .NET 8.0

─────────────────────────────────────────────────────────────────
  GROUP: Auth / User  (TC01 – TC05)
─────────────────────────────────────────────────────────────────
  ✅ PASS  TC01_ValidEmail_ShouldReturnTrue                  0.05s
  ✅ PASS  TC02_InvalidEmail_MissingAt_ShouldReturnFalse     0.02s
  ✅ PASS  TC03_PasswordMinLength_ShouldBeValid              0.01s
  ✅ PASS  TC04_PasswordTooShort_ShouldBeInvalid             0.01s
  ✅ PASS  TC05_HashAndVerifyPassword_ShouldMatch            0.08s

─────────────────────────────────────────────────────────────────
  GROUP: Product  (TC06 – TC10)
─────────────────────────────────────────────────────────────────
  ✅ PASS  TC06_FilterByCategory_ShouldReturnCorrectProducts 0.02s
  ✅ PASS  TC07_SearchProduct_CaseInsensitive_ShouldWork     0.01s
  ✅ PASS  TC08_SortByPriceAsc_ShouldOrderCorrectly          0.01s
  ✅ PASS  TC09_CalcStockPercent_OutOfStock_ShouldReturn100  0.01s
  ✅ PASS  TC10_CalcStockPercent_NeverExceeds95              0.01s

─────────────────────────────────────────────────────────────────
  GROUP: Cart  (TC11 – TC15)
─────────────────────────────────────────────────────────────────
  ✅ PASS  TC11_AddToCart_OutOfStock_ShouldFail              0.01s
  ✅ PASS  TC12_AddToCart_ExceedsStock_ShouldFail            0.02s
  ✅ PASS  TC13_AddToCart_ValidQuantity_ShouldSucceed        0.01s
  ✅ PASS  TC14_CartDTO_GrandTotal_ShouldBeCorrect           0.01s
  ✅ PASS  TC15_ClampQuantity_ShouldRespectBounds            0.01s

─────────────────────────────────────────────────────────────────
  GROUP: Order  (TC16 – TC20)
─────────────────────────────────────────────────────────────────
  ✅ PASS  TC16_CancelOrder_PendingStatus_ShouldBeAllowed    0.01s
  ✅ PASS  TC17_CancelOrder_ShippingStatus_ShouldBeForbidden 0.01s
  ✅ PASS  TC18_CancelOrder_DoneStatus_ShouldBeForbidden     0.01s
  ✅ PASS  TC19_CalcOrderTotal_FromCartItems_ShouldBeCorrect 0.01s
  ✅ PASS  TC20_GetStatusLabel_ShouldReturnCorrectLabel      0.02s

═════════════════════════════════════════════════════════════════
  SUMMARY
  Total:   20    Passed: 20    Failed: 0    Skipped: 0
  Duration: 0.34s
═════════════════════════════════════════════════════════════════
