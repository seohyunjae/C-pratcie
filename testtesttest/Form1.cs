using DevExpress.DataProcessing;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using GST.PlusWin6.Controls;
using GST.PlusWin6.Core.Forms;
using GST.PlusWin6.Core.Library;
using GST.PlusWin6.Utils;
using GST.PlusWin6.Utils.Localization;
using GST.PlusWin6.Utils.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace GST.PlusWin6.Forms
{
    public partial class SA_A2000 : BaseForm
    {
        #region [FILED]
        private DataTable _unitPriceDate;
        private bool Is바이오톡스텍 { get { return Config.CompanyCode.Equals("2302BA03") || Config.CompanyCode.Equals("2310EA77") || Config.CompanyCode.Equals("2310F434"); } }
        private bool IsFNF { get { return Config.CompanyCode.Equals("2402CFAE"); } }
        private bool Is디씨엠 { get { return Config.CompanyCode.Equals("2401CCA3"); } }
        private bool Is휘앤비 { get { return Config.CompanyCode.Equals("2310C3F2"); } }
        private bool IsGST { get { return Config.CompanyCode.Equals("2301A110"); } }
        private bool IsDEV { get { return Config.CompanyCode.Equals("2207A046"); } }
        private bool Is탈렌트엘엔지 { get { return Config.CompanyCode.Equals("2402D8D4"); } }


        #endregion [FILED]

        public SA_A2000(params object[] args) : base(ref args)
        {
            InitializeComponent();
            grpTop.CustomHeaderButtons.FindFirst(x
                => x.Properties.Tag.Equals("reset")).Properties.ToolTip = Messages.InitializeSearchParameters;

            grpTop.CustomButtonClick += GroupControl_CustomButtonClick;
            grpList.CustomButtonClick += GroupControl_CustomButtonClick;
            grpDetail.CustomButtonClick += GroupControl_CustomButtonClick;

            bteFile.ButtonClick += BteFile_ButtonClick;
            repositoryItemButtonEditEx2.ButtonClick += RepositoryItemButtonEditEx2_ButtonClick;
            btnChange.Click += btnChange_Click;

            gvwList.FocusedRowChanged += GridView_FocusedRowChanged;

            gvwDetail.CellValueChanged += GridView_CellValueChanged;

            ymdOrddt.EditValueChanged += ControlEx_EditValueChanged;
            cboAmtunit.EditValueChanged += ControlEx_EditValueChanged;
            bteCustcd1.EditValueChanged += ControlEx_EditValueChanged;
            numWonchgrat.EditValueChanged += ControlEx_EditValueChanged;
            numUschgrat.EditValueChanged += ControlEx_EditValueChanged;
            cboTaxdiv.EditValueChanged += ControlEx_EditValueChanged;
            txtHullno1.EditValueChanged += ControlEx_EditValueChanged;

            gvwDetail.ShowingEditor += GvwDetail_ShowingEditor;

            RetrieveHelper.AddFindRowInfo(gvwList, "ordnum", null);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (IsFNF)
            {
                riBteItemcd.BizComponentId = "P_ITEMCD_628";
            }

            if (Is탈렌트엘엔지)
            {
                lblHullno.Visible = true;
                txtHullno.Visible = true;
                lblHullno1.Visible = true;
                txtHullno1.Visible = true;

                lblHullno.Location = new Point(1249, 6);
                txtHullno.Location = new Point(1350, 6);

                txtProject.Size = new System.Drawing.Size(343, 24);

                // 기존 BizComponentId 제거
                bteCustcd.BizComponentId = null;
                bteCustcd.SelectItems.Clear();

                bteCustcd1.BizComponentId = null;
                bteCustcd1.SelectItems.Clear();

                bteCustcd.ButtonClick += (s, e1) =>
                {
                    // 팝업 열리기전 파라미터 들어갈 상황이면 추가
                    Hashtable ht = new Hashtable();
                    ht.Add("custcd", bteCustcd.Text);
                    ht.Add("custnm", txtCustnm.Text);

                    OpenFormByPopup("BA_P0020_626", ht, out BaseForm formInfo);

                    if (formInfo.DialogResult == DialogResult.OK)
                    {
                        // 값 세팅
                        Hashtable result = formInfo.FormResult as Hashtable;
                        bteCustcd.Text = result["custcd"].ToString();
                        txtCustnm.Text = result["custnm"].ToString();
                    }

                };
                bteCustcd1.ButtonClick += (s, e1) =>
                {
                    // 팝업 열리기전 파라미터 들어갈 상황이면 추가
                    Hashtable ht = new Hashtable();
                    ht.Add("custcd", bteCustcd1.Text);
                    ht.Add("custnm", txtCustnm1.Text);

                    OpenFormByPopup("BA_P0020_626", ht, out BaseForm formInfo);

                    if (formInfo.DialogResult == DialogResult.OK)
                    {
                        // 값 세팅
                        Hashtable result = formInfo.FormResult as Hashtable;
                        bteCustcd1.Text = result["custcd"].ToString();
                        txtCustnm1.Text = result["custnm"].ToString();
                    }
                };
            }

            base.OnLoad(e);

            ResetParameters();

            if (Config.IsAdministrator)
            {
                // 관리자만 정보(사업장, 부서, 담당자) 수정 가능
                cboLocation1.Properties.ReadOnly = false;  // 사업장
                cboDptcd.Properties.ReadOnly = false;      // 부서
                cboPerson1.Properties.ReadOnly = false;	   // 담당자
            }
            if (Is바이오톡스텍)
            {
                grpDetail.CustomHeaderButtons["[발주참조팝업]"].Properties.Visible = true;

                lblOrdsts.Visible = false;
                cboOrdsts.Visible = false;
                lblOrdtype.Visible = false;
                cboOrdtype.Visible = false;
                lblDoexdiv.Visible = false;
                cboDoexdiv.Visible = false;
                lblOrdnum.Visible = false;
                txtOrdnum.Visible = false;

                lblDoexdiv1.Visible = false;
                cboDoexdiv1.Visible = false;
                cboDoexdiv1.AllowBlank = true;
                lblUschgrat.Visible = false;
                numUschgrat.Visible = false;
                lblShipMethod.Visible = false;
                txtShipMethod.Visible = false;
                lblProject.Visible = false;
                txtProject.Visible = false;

                // 조회조건 위치 조정
                lblPoregnum.Location = new System.Drawing.Point(460, 34);
                txtPoregnum.Location = new System.Drawing.Point(561, 34);
                lblFinyn.Location = new System.Drawing.Point(460, 64);
                radFinyn_g.Location = new System.Drawing.Point(561, 64);
                lblPerson.Location = new System.Drawing.Point(726, 34);
                cboPerson.Location = new System.Drawing.Point(827, 34);

                // 기본정보 위치 조정
                lblPrcterms.Location = new System.Drawing.Point(904, 38);
                txtPrcterms.Location = new System.Drawing.Point(1005, 38);
                txtPrcterms.Size = new System.Drawing.Size(120, 24);
                lblLocation1.Location = new System.Drawing.Point(904, 68);
                cboLocation1.Location = new System.Drawing.Point(1005, 68);
                lblTaxdiv.Location = new System.Drawing.Point(681, 8);
                cboTaxdiv.Location = new System.Drawing.Point(782, 8);
                lblPortnm.Location = new System.Drawing.Point(904, 8);
                txtPortnm.Location = new System.Drawing.Point(1005, 8);
                txtPortnm.Size = new System.Drawing.Size(120, 24);
                lblPaymeth.Location = new System.Drawing.Point(681, 128);
                txtPaymeth.Location = new System.Drawing.Point(782, 128);
                txtPaymeth.Size = new System.Drawing.Size(343, 24);

                lblUrgencyyn.Location = new System.Drawing.Point(1126, 8);
                chkUrgencyyn.Location = new System.Drawing.Point(1228, 8);

                MemoRemark.Size = new System.Drawing.Size(1011, 66);
            }

            if (IsGST || IsDEV)
            {
                AttachmentHelper.AddAttachmentGridInfo(gvwDetail, gvwDetail.Columns["attdatnum"], gvwDetail.Columns["files"]);
                col_insiz.OptionsColumn.AllowEdit = true;
                col_insiz.OptionsColumn.ReadOnly = false;
                col_remark2_1.WordText = "발주처";
                col_remark2_1.OptionsColumn.AllowEdit = true;
                col_remark2_1.OptionsColumn.ReadOnly = false;
            }

            if (IsFNF)
            {
                col_dlvdt.SummaryItem.DisplayFormat = "{0}건";
                col_dlvdt.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;

                riNumUnp.DecimalCode = "";
                riNumUnp.DecimalPoint = 4;

                col_itemnm.OptionsColumn.AllowEdit = true;
                /// 수주상태
                // 조회조건
                lblOrdtype.Visible = false;
                cboOrdtype.Visible = false;
                lblOrddiv.Visible = true;
                cboOrddiv.Visible = true;
                cboOrdsts1.AllowBlank = true;
                lblOrddiv.Location = lblOrdtype.Location;
                cboOrddiv.Location = cboOrdtype.Location;
                ymdDlvdt.Visible = false;
                lblDlvdt.Visible = false;
                // 기본정보
                lblOrdsts1.Visible = false;
                cboOrdsts1.Visible = false;
                lblOrddiv1.Visible = true;
                cboOrddiv1.Visible = true;
                lblOrddiv1.Location = lblOrdsts1.Location;
                cboOrddiv1.Location = cboOrdsts1.Location;
                repositoryItemLookUpEditEx2.BizComponentId = "L_SA004";
                cboOrdsts.BizComponentId = "L_SA004";
                cboOrdsts1.BizComponentId = "L_SA004";
                cboOrdsts2.BizComponentId = "L_SA004";
                RefreshLookUpItems(cboOrdsts, true);
                RefreshLookUpItems(cboOrdsts1, true);
                RefreshLookUpItems(cboOrdsts2, true);
                RefreshLookUpItems(repositoryItemLookUpEditEx2, true);
                chkUrgencyyn.Visible = false;
                lblUrgencyyn.Visible = false;
                col_rcvcustcd1.WordText = "납품처코드";
                lblFinyn.WordText = "상태변경";
                radFinyn_g.Visible = false;
                radFinyn2_g.Location = radFinyn_g.Location;
                radFinyn2_g.Visible = true;
                lblChange.Visible = true;
                cboOrdsts2.Visible = true;
                btnChange.Visible = true;
                lblDoexdiv.WordText = "납품처";
                cboDoexdiv.Visible = false;
                txtRemark2.Visible = true;
                txtRemark2.Location = cboDoexdiv.Location;

                cboTaxdiv.Visible = false;
                lblTaxdiv.Visible = false;
                MemoRemark.Height = MemoRemark.Height / 2;
                grpList.Height = grpList.Height + 50;
                grpMaster.Height = grpMaster.Height - 40;
            }
            else if (Is디씨엠)
            {
                col_out_qty.WordText = "출고수량";
                col_remark.WordText = "비고사항";
            }
            SetReadOnlyRecursive(bteFile, true, false);
            SetReadOnlyRecursive(txtOrdnum1, true);
        }

        private void AddExpressionRuleToGridView(GridView view, GridColumn gridColumn, string expression,
             bool applyToRow = false, Font font = null, Color? backColor = null, Color? foreColor = null)
        {
            var formatRule = new DevExpress.XtraGrid.GridFormatRule();
            var conditionRuleValue = new DevExpress.XtraEditors.FormatConditionRuleValue();

            conditionRuleValue.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            conditionRuleValue.Expression = expression ?? string.Empty;

            if (font != null)
                conditionRuleValue.Appearance.Font = font;
            if (backColor != null)
                conditionRuleValue.Appearance.BackColor = (Color)backColor;
            if (foreColor != null)
                conditionRuleValue.Appearance.ForeColor = (Color)foreColor;

            formatRule.Rule = conditionRuleValue;
            formatRule.ApplyToRow = applyToRow;
            formatRule.Column = gridColumn;

            view.FormatRules.Add(formatRule);
        }

        protected override void InitBaseButtons()
        {
            base.InitBaseButtons();
        }

        protected override void ClickRetrieveButton()
        {
            AttachmentHelper.AcceptChanges();

            RetrieveHelper.Begin(gvwList);
            if (Retrieve("Q", out _))
            {
                RetrieveHelper.FindRow(gvwList);
            }
            RetrieveHelper.End(gvwList);
        }

        protected override void ClickNewButton()
        {
            AttachmentHelper.AcceptChanges();

            InitControlsRecursive(scrMaster);
            InitControlsRecursive(grpDetail);

            ymdOrddt.EditValue = GetDefault("NEW", nameof(ymdOrddt));
            ymdDlvdt.EditValue = GetDefault("NEW", nameof(ymdDlvdt));
            cboDptcd1.EditValue = GetDefault("NEW", nameof(cboDptcd));
            cboPerson1.EditValue = GetDefault("NEW", nameof(cboPerson1), Config.UserId);
            cboLocation1.EditValue = GetDefault("NEW", nameof(cboLocation1), Config["location"]);
            cboDoexdiv1.EditValue = GetDefault("NEW", nameof(cboDoexdiv), "A");
            cboOrdsts1.EditValue = GetDefault("NEW", nameof(cboOrdsts), "2");
            cboTaxdiv.EditValue = GetDefault("NEW", nameof(cboTaxdiv), "A");
            cboAmtunit.EditValue = GetDefault("NEW", nameof(cboAmtunit), "KRW");
            cboOrdtype1.EditValue = GetDefault("NEW", nameof(cboOrdtype), "A");
            cboOrddiv1.EditValue = GetDefault("NEW", nameof(cboOrddiv1), "");

            if (Is디씨엠)
            {
                PopItemMulti();
            }
        }

        protected override void ClickCopyButton()
        {
            if (string.IsNullOrEmpty(txtOrdnum1.Text))
            {
                ShowMessageBox(GetFormMessage("SA_A2000_003", ""), "복사 오류", MessageFormButtons.OK, MessageFormIcon.Warning); //저장 후 복사가능합니다.
                return;
            }
            if (ShowMessageBox(GetFormMessage("SA_A2000_004", ""), "수주정보 복사", MessageFormButtons.YesNo) != DialogResult.Yes) //해당 수주를 복사하시겠습니까?
            {
                return;
            }

            txtOrdnum1.Text = string.Empty;
            txtAttdatnum.Text = string.Empty;
            bteFile.Text = string.Empty;

            DataTable source = grdDetail.DataSource as DataTable;

            source.AsEnumerable().ToList<DataRow>().ForEach(
                row =>
                {
                    row.SetAdded();
                    row["chk"] = "";
                    row["ordnum"] = "";
                    row["ordseq"] = 0;
                    row["ordkey"] = "";
                    row["finyn"] = "";
                }
            );

        }

        protected override void ClickSaveButton()
        {
            if (ExecuteSave(string.IsNullOrEmpty(txtOrdnum1.Text) ? "N" : "U"))
            {
                ClickRetrieveButton();
            }
        }

        protected override void ClickDeleteButton()
        {
            if (gvwList.FocusedRowHandle < 0)
            {
                MessageForm.Show(Messages.NoRowSelected);
                return;
            }
            if (MessageForm.Show(Messages.QuestionToDelete, "", MessageFormButtons.YesNo, MessageFormIcon.Question) == DialogResult.Yes)
            {
                if (ExecuteSave("D"))
                {
                    ClickRetrieveButton();
                }
            }
        }

        protected override void ClickPreviewButton()
        {
            Print("PREVIEW");
        }

        protected override void ClickPrintButton()
        {
            Print("PRINT");
        }

        private void Print(string workType)
        {
            if (gvwDetail.RowCount <= 0)
            {
                ShowMessageBox(GetFormMessage("SA_A2000_007", "출력할 수주상세 정보가 없습니다."));
                return;
            }

            Retrieve("REPORT", out DataTable dt);
            XtraReport report;
            if (Is휘앤비)
            {
                report = new OrderReport_615(dt);
            }
            else
            {
                report = new XtraReport1(dt);
            }

            if (workType.Equals("PRINT"))
            {
                report.Print();
            }
            else // if (workType.Equals("PREVIEW"))
            {
                report.ShowPreviewDialog();
            }

        }

        private void ResetParameters()
        {
            InitControlsRecursive(grpTop);

            cboDtgb.EditValue = GetDefault("QUERY", nameof(cboDtgb));
            ymdFrdt.EditValue = GetDefault("QUERY", nameof(ymdFrdt));
            ymdTodt.EditValue = GetDefault("QUERY", nameof(ymdTodt));
            cboLocation.EditValue = GetDefault("QUERY", nameof(cboLocation), "01");
            radFinyn_g.EditValue = GetDefault("QUERY", nameof(radFinyn_g), "%");
            radFinyn2_g.EditValue = GetDefault("QUERY", nameof(radFinyn2_g), "N");
        }

        private void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (sender is GridView view)
            {
                FocusedRowChanged(view);
            }
        }

        public override void FocusedRowChanged(ColumnView view)
        {
            if (view.Equals(gvwList))
            {
                if (view.RowCount > 0 && view.FocusedRowHandle >= 0)
                {
                    if (!RetrieveHelper.IsFindingRowHandle(view))
                    {
                        FillValuesFromReferenceControl(scrMaster, grdList);
                        Retrieve("DETAIL", out _);

                        if (IsFNF)
                        {
                            gvwDetail.FormatRules.Clear(); /* 중요 */

                            // Rule 추가
                            AddExpressionRuleToGridView(
                                                        gvwDetail,
                                                        col_ordsts1,
                                                        "[ordsts] = 1",
                                                        applyToRow: true,
                                                        foreColor: Color.Red
                                                        );
                        }
                    }
                }
                else
                {
                    InitControlsRecursive(scrMaster);
                    InitControlsRecursive(grpDetail);
                }

                AttachmentHelper.AcceptChanges();
            }
        }

        private void GroupControl_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            (sender as Control)?.Focus();
            string tagValue = e.Button?.Properties?.Tag?.ToString() ?? string.Empty;

            if (sender.Equals(grpTop))
            {
                if (tagValue.Equals("reset"))
                {
                    ResetParameters();
                }
            }
            else if (sender.Equals(grpList))
            {
                if (tagValue.Equals("show"))    // 기본정보 표시/숨김
                {
                    grpMaster.Visible = !grpMaster.Visible;
                }
            }
            else if (sender.Equals(grpDetail))
            {
                if (tagValue.Equals("add"))
                {
                    DataRow newRow = AddNewRowToGrid(grdDetail, gvwDetail.RowCount);
                    if (IsFNF)
                    {
                        newRow.SetValue("ordsts", "1");
                        newRow.SetValue("dlvdt", GetServerDateTime());
                        newRow.SetValue("qtyunit", "KG");
                    }
                }
                // 선택항목 삭제
                else if (tagValue.Equals("remove"))
                {
                    DataRow[] rows = (grdDetail.DataSource as DataTable).Select("chk = 'Y'");
                    DeleteRowInGrid(grdDetail, rows, false);
                }
                // 선택항목 복사
                else if (tagValue.Equals("copy"))
                {
                    DataRow[] targetRows = (grdDetail.DataSource as DataTable).Select("chk = 'Y'");

                    if ((targetRows?.Length ?? 0) == 0)
                    {
                        ShowMessageBox(Messages.NoRowSelected);
                        return;
                    }
                    grdDetail.BeginUpdate();
                    foreach (DataRow targetRow in targetRows)
                    {
                        // 신규 행 추가
                        DataRow newRow = AddNewRowToGrid(grdDetail, gvwDetail.RowCount);

                        foreach (DataColumn targetColumn in targetRow.Table.Columns)
                        {
                            newRow.SetValue(targetColumn.ColumnName, targetRow.GetValue(targetColumn.ColumnName));
                        }
                        if (IsFNF)
                        {
                            newRow.SetValue("ordsts", "2");
                        }
                        newRow.SetValue("chk", "N");
                    }
                    grdDetail.EndUpdate();
                }
                // 품목참조[멀티]
                else if (tagValue.Equals("PopItemMulti"))
                {
                    PopItemMulti();
                }
                // 강제 완료/해제
                else if (tagValue.Equals("Finish"))
                {
                    DataRow[] targetRows = (grdDetail.DataSource as DataTable).Select("chk = 'Y'");

                    if ((targetRows?.Length ?? 0) == 0)
                    {
                        ShowMessageBox(Messages.NoRowSelected);
                        return;
                    }
                    // 행추가 후 저장하지 않은 항목이 있을 경우
                    if ((grdDetail.DataSource as DataTable)?.AsEnumerable().FirstOrDefault(row => row.RowState == DataRowState.Added) != null)
                    {
                        ShowMessageBox(GetFormMessage("SA_A2000_009", "상세정보 저장 후 강제완료 처리가능합니다."), "오류", MessageFormButtons.OK, MessageFormIcon.Warning);
                    }
                    if (ShowMessageBox(GetFormMessage("SA_A2000_010", "선택한 자료를 강제완료/완료해제 처리합니다."), "강제완료", MessageFormButtons.YesNo, MessageFormIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }

                    if (ExecuteSave("Finish"))
                    {
                        ClickRetrieveButton();
                    }
                }
                // 발주참조팝업
                else if (tagValue.Equals("purRef"))
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("custcd", bteCustcd.Text);
                    ht.Add("custnm", txtCustnm.Text);

                    SA_A2000_Sub1 popup = CreateSubForm<SA_A2000_Sub1>();
                    popup.ParentParameter = ht;

                    if (popup.ShowDialog() == DialogResult.OK)
                    {
                        DataTable source = (DataTable)popup.FormResult;

                        if ((source?.Rows?.Count ?? 0) > 0)
                        {
                            if (string.IsNullOrEmpty(txtOrdnum1.Text))
                            {
                                bteCustcd1.Text = source.Rows[0]["custcd"]?.ToString() ?? string.Empty;
                                txtCustnm1.Text = source.Rows[0]["custnm"]?.ToString() ?? string.Empty;
                            }

                            gvwDetail.CellValueChanged -= GridView_CellValueChanged;

                            try
                            {
                                foreach (DataRow targetRow in source.Rows)
                                {
                                    // 신규 행 추가
                                    DataRow newRow = AddNewRowToGrid(grdDetail, gvwDetail.RowCount); ;

                                    // 대상 DataRow의 컬럼을 반복
                                    foreach (DataColumn targetColumn in targetRow.Table.Columns)
                                    {
                                        // SetValue 확장 메서드는 존재하지 않는 ColumnName 일 경우 처리하지 않도록 예외 처리 되어 있음
                                        newRow.SetValue(targetColumn.ColumnName, targetRow.GetValue(targetColumn.ColumnName));
                                    }

                                    // 별도 DataColumn에 대한 처리
                                    newRow.SetValue("chk", string.Empty);
                                    newRow.SetValue("remark", string.Empty);
                                    newRow.SetValue("unpcalmeth", "Q");
                                    newRow.SetValue("inordnum", targetRow.GetValue("purnum"));
                                    newRow.SetValue("inordseq", targetRow.GetValue("purseq"));
                                    newRow.SetValue("qty", targetRow.GetValue("doqty"));
                                    newRow.SetValue("insiz", targetRow.GetValue("insiz"));
                                    newRow.SetValue("qtyunit", targetRow.GetValue("qtyunit"));

                                    // 금액 계산 
                                    CalculateAmountOfGridDetail("amount1", gvwDetail.FocusedRowHandle);
                                }
                            }
                            catch
                            {
                                throw;
                            }
                            finally
                            {
                                gvwDetail.CellValueChanged += GridView_CellValueChanged;
                            }
                        }
                    }
                }
            }
        }

        private void BteFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            AttachmentHelper.OpenAttachmentsPopup(txtAttdatnum, bteFile);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvwDetail.RowCount; i++)
            {
                if (gvwDetail.GetRowCellValue(i, "chk").Equals("Y"))
                {
                    gvwDetail.SetRowCellValue(i, "ordsts", cboOrdsts2.EditValue.ToString());
                }
            }
        }

        public void ControlEx_EditValueChanged(object sender, EventArgs e)
        {

            if (sender.Equals(ymdOrddt) || sender.Equals(cboAmtunit) || sender.Equals(bteCustcd1))
            {
                if (sender.Equals(ymdOrddt))
                {
                    if (ymdOrddt.Text.Replace("-", "").Length != 8)
                    {
                        return;
                    }
                }

                if (scrMaster.DataStatus.Equals("Q"))
                {
                    return;
                }

                if (!IsFNF)
                {
                    _unitPriceDate = CalculationHelper.GetUnitPriceData(Core.UnitPriceType.Sales, bteCustcd1.Text);

                    if (scrMaster.DataStatus.Equals("U") && !string.IsNullOrEmpty(txtOrdnum1.Text))
                    {
                        //  환율 및 단가를 변경하시겠습니까?
                        if (ShowMessageBox(GetFormMessage("SA_A2000_016", "", false), "안내", MessageFormButtons.YesNo).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }

                    GetRate();

                    gvwDetail.CellValueChanged -= GridView_CellValueChanged;
                    try
                    {
                        for (int i = 0; i < gvwDetail.RowCount; i++)
                        {
                            CalculateAmountOfGridDetail("unp", i);
                            CalculateAmountOfGridDetail("amount1", i);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        gvwDetail.CellValueChanged += GridView_CellValueChanged;
                    }
                }
            }

            else if (sender.Equals(numWonchgrat) || sender.Equals(numUschgrat) || sender.Equals(cboTaxdiv))
            {
                gvwDetail.CellValueChanged -= GridView_CellValueChanged;
                try
                {
                    for (int i = 0; i < gvwDetail.RowCount; i++)
                    {
                        CalculateAmountOfGridDetail("amount2", i);
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    gvwDetail.CellValueChanged += GridView_CellValueChanged;
                }

            }
            else if (sender.Equals(cboOrdtype1)) // 기본정보의 수주형태
            {
                // 수주형태가 '내수'일때 내수구분에 '내수'로 세팅
                if (cboOrdtype.EditValue.Equals("A"))
                {
                    cboDoexdiv.EditValue = "A"; // 내수
                    cboTaxdiv.EditValue = "A";  // 과세
                }
                // 그 외 수출 / 영세로 셋팅
                else
                {
                    cboDoexdiv.EditValue = "B"; // 수출
                    cboTaxdiv.EditValue = "B";  // 영세
                }
            }
            else if (sender.Equals(txtHullno1))
            {
                string hullno = txtHullno1.Text;

                DataTable source = (grdDetail.DataSource as DataTable);

                DataRow[] targetRow = source?.AsEnumerable()?.Where(x => x.RowState != DataRowState.Deleted)?.ToArray() ?? new DataRow[0];

                foreach (DataRow row in targetRow)
                {
                    row.SetValue("hullno", hullno);
                }
            }
        }

        private void GvwDetail_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 바이오톡스텍 발주참조하여 등록하는 경우 수량 컬럼 잠금 처리 
            if (Is바이오톡스텍 && gvwDetail.FocusedColumn.FieldName.Equals("qty"))
            {
                if (string.IsNullOrEmpty(gvwDetail.GetFocusedRowCellValue("inordnum").ToString()))
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void RepositoryItemButtonEditEx2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            AttachmentHelper.OpenAttachmentsPopup(grdDetail);
        }

        private void CalculateAmountOfGridDetail(string calcType, int iRow)
        {
            GridViewEx gvw = gvwDetail as GridViewEx;

            decimal unp = decimal.Parse(gvw.GetRowCellValue(iRow, "unp")?.ToString() ?? "0");
            decimal qty = decimal.Parse(gvw.GetRowCellValue(iRow, "qty")?.ToString() ?? "0");
            decimal unitwgt = decimal.Parse(gvw.GetRowCellValue(iRow, "unitwgt")?.ToString() ?? "0");
            decimal totwgt = decimal.Parse(gvw.GetRowCellValue(iRow, "totwgt")?.ToString() ?? "0");
            decimal amt = decimal.Parse(gvw.GetRowCellValue(iRow, "amt")?.ToString() ?? "0");
            decimal specialunp = decimal.Parse(gvw.GetRowCellValue(iRow, "specialunp")?.ToString() ?? "0");

            decimal wonchgrat = numWonchgrat.Value;
            decimal uschgrat = numUschgrat.Value;
            decimal baseamt = numBaseamt.Value;

            string amtunit = cboAmtunit.EditValue.ToString();
            string taxdiv = "";
            if (IsFNF)
            {
                taxdiv = gvw.GetRowCellValue(iRow, "taxdiv")?.ToString();
            }
            else
            {
                taxdiv = cboTaxdiv.EditValue.ToString();
            }

            string itemcd = gvw.GetRowCellValue(iRow, "itemcd").ToString();
            string itemacnt = gvw.GetRowCellValue(iRow, "itemacnt").ToString();
            decimal decCalamt = 0;
            decimal decCalunp = 0;

            if (calcType.Equals("amount1"))
            {
                if (IsFNF)
                {
                    if (taxdiv.Equals("B") || taxdiv.Equals("C"))
                    {
                        decCalamt = qty * unp;
                    }
                    else
                    {
                        decCalamt = (qty * unp) / Convert.ToDecimal(1.1);
                    }
                }
                else
                {
                    decCalamt = qty * unp;
                }
                Core.Models.ResultAmountInfo result = CalculationHelper.Amount(decCalamt, amtunit, taxdiv, wonchgrat, uschgrat, baseamt);

                gvw.SetRowCellValue(iRow, "amt", decCalamt);
                gvw.SetRowCellValue(iRow, "wonamt", result.KRW);
                gvw.SetRowCellValue(iRow, "taxamt", result.Tax);
                gvw.SetRowCellValue(iRow, "dlramt", result.USD);
                gvw.SetRowCellValue(iRow, "totamt", result.KRW + result.Tax);
            }
            else if (calcType.Equals("amount2"))
            {
                if (IsFNF)
                {
                    amt = (qty * unp) / Convert.ToDecimal(1.1);
                }
                else
                {
                    amt = qty * unp;
                }

                Core.Models.ResultAmountInfo result = CalculationHelper.Amount(amt, amtunit, taxdiv, wonchgrat, uschgrat, baseamt);
                gvw.SetRowCellValue(iRow, "wonamt", result.KRW);
                gvw.SetRowCellValue(iRow, "taxamt", result.Tax);
                gvw.SetRowCellValue(iRow, "dlramt", result.USD);
                gvw.SetRowCellValue(iRow, "totamt", result.KRW + result.Tax);
            }
            else if (calcType.Equals("wgt"))
            {
                gvw.SetRowCellValue(iRow, "wgt", unitwgt * qty);
            }
            else if (calcType.Equals("unp"))
            {
                if (IsFNF)
                {
                    if (!string.IsNullOrEmpty(itemcd))
                    {
                        Retrieve("unp_628", out DataTable resultdt);
                        if (resultdt != null && resultdt.Rows.Count > 0)
                        {
                            decCalunp = decimal.Parse(resultdt.Rows[0]["unp"]?.ToString() ?? "0");
                            string origin = resultdt.Rows[0]["origin"]?.ToString() ?? string.Empty;
                            gvw.SetRowCellValue(iRow, "unp", decCalunp);
                            gvw.SetRowCellValue(iRow, "origin", origin);
                        }
                    }
                }
                else
                {
                    decCalunp = string.IsNullOrEmpty(bteCustcd1.Text) ? 0 : CalculationHelper.GetUnitPrice(_unitPriceDate, itemcd, itemacnt, ymdOrddt.yyyyMMdd, amtunit);
                    gvw.SetRowCellValue(iRow, "unp", decCalunp);
                }

            }
            else if (calcType.Equals("specialunp"))
            {
                gvw.SetRowCellValue(iRow, "specialamt", specialunp * qty);
            }
        }

        private void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (sender.Equals(gvwDetail))
            {
                gvwDetail.CellValueChanged -= GridView_CellValueChanged;
                try
                {
                    switch (e.Column.FieldName)
                    {
                        case "unp":
                        case "qty":
                        case "transrate":

                            CalculateAmountOfGridDetail("amount1", e.RowHandle);

                            //에프앤에프 환산수량 로직
                            if (IsFNF)
                            {
                                decimal qty = Convert.ToDecimal(gvwDetail.GetFocusedRowCellValue("qty").ToString());
                                decimal transrate = Convert.ToDecimal(gvwDetail.GetFocusedRowCellValue("transrate").ToString());
                                decimal boxqty = transrate == 0 ? 0 : qty / transrate;

                                gvwDetail.SetFocusedRowCellValue("boxqty", boxqty);
                            }

                            break;
                        case "amt":
                            CalculateAmountOfGridDetail("amount2", e.RowHandle);
                            break;

                        case "itemcd":
                        case "itemacnt":
                            CalculateAmountOfGridDetail("unp", e.RowHandle);
                            CalculateAmountOfGridDetail("amount1", e.RowHandle);
                            break;

                        case "unitwgt":
                            CalculateAmountOfGridDetail("wgt", e.RowHandle);
                            break;

                        case "specialunp":
                            CalculateAmountOfGridDetail("specialunp", e.RowHandle);
                            break;
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    gvwDetail.CellValueChanged += GridView_CellValueChanged;
                }
            }
        }

        private void GetRate()  // 환율 
        {
            string amtunit = cboAmtunit.EditValue.ToString();

            Dictionary<string, ExchangeRateInfo> rate = new Dictionary<string, ExchangeRateInfo>();
            rate = CalculationHelper.GetExchangeRateInfos(ymdOrddt.yyyyMMdd, true);

            if (rate.Count != 0 && rate.ContainsKey(amtunit))
            {
                numWonchgrat.Value = decimal.Parse(rate[amtunit].ExchangeRateKRW.ToString());
                numUschgrat.Value = decimal.Parse(rate[amtunit].ExchangeRateUSD.ToString());
                numBaseamt.Value = decimal.Parse(rate[amtunit].BaseAmount.ToString());
            }
            else
            {
                numWonchgrat.Value = 1;
                numUschgrat.Value = 0;
                numBaseamt.Value = 1;
            }
            if (numBaseamt.Value.Equals(0))
            {
                numBaseamt.Value = 1;
            }
        }

        private void PopItemMulti()
        {
            OpenFormByPopup("BA_P0040", null, out BaseForm form);

            if (form.FormResult is DataTable dt)
            {
                gvwDetail.CellValueChanged -= GridView_CellValueChanged;
                try
                {
                    foreach (DataRow targetRow in dt.Rows)
                    {
                        DataRow newRow = AddNewRowToGrid(grdDetail, gvwDetail.RowCount);

                        foreach (DataColumn targetColumn in targetRow.Table.Columns)
                        {
                            newRow.SetValue(targetColumn.ColumnName, targetRow.GetValue(targetColumn.ColumnName));
                        }
                        newRow.SetValue("qtyunit", targetRow["invunit"]);
                        newRow.SetValue("amtunit", cboAmtunit.EditValue.ToString());
                        newRow.SetValue("orddt", ymdOrddt.yyyyMMdd);
                        newRow.SetValue("dlvdt", ymdDlvdt.yyyyMMdd);

                        if (IsFNF)
                        {
                            newRow.SetValue("ordsts", "1");
                            newRow.SetValue("dlvdt", GetServerDateTime());
                            newRow.SetValue("remark", string.Empty);
                            newRow.SetValue("ordsiz", targetRow.Field<string>("spec"));
                        }
                        // 단가 셋팅 
                        CalculateAmountOfGridDetail("unp", gvwDetail.FocusedRowHandle);
                        CalculateAmountOfGridDetail("amount1", gvwDetail.FocusedRowHandle);
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    gvwDetail.CellValueChanged += GridView_CellValueChanged;
                }
            }
        }

        private bool Retrieve(string workType, out DataTable dt)
        {
            dt = null;

            if (!ValidateControls(grpTop))
            {
                return false;
            }

            string ordnum = string.Empty;
            string custcd = string.Empty;
            string custnm = string.Empty;
            string itemcd = string.Empty;
            string itemnm = string.Empty;
            string finyn = string.Empty;

            if (IsFNF)
            {
                finyn = radFinyn2_g.EditValue.ToString();
            }
            else
            {
                finyn = radFinyn_g.EditValue.ToString();
            }
            if (workType.Equals("Q"))
            {
                ordnum = txtOrdnum.Text;
                custcd = bteCustcd.Text;
                custnm = txtCustnm.Text;
                itemcd = bteItemcd.Text;
                itemnm = txtItemnm.Text;
            }
            else if (workType.Equals("unp_628"))
            {
                custcd = bteCustcd1.Text;
                itemcd = gvwDetail.GetFocusedRowCellValue("itemcd").ToString();
            }
            else
            {
                ordnum = txtOrdnum1.Text;
                custcd = bteCustcd.Text;
                custnm = txtCustnm.Text;
                itemcd = bteItemcd.Text;
                itemnm = txtItemnm.Text;
            }

            var procInfo = new P_SA_A2000_Q();
            procInfo.SetParamValues(
                workType,
                Config["orgdiv"],
                cboLocation.EditValue.ToString(),
                cboDtgb.EditValue.ToString(),
                ymdFrdt.yyyyMMdd,
                ymdTodt.yyyyMMdd,
                ymdOrddt.yyyyMMdd,
                ordnum,
                custcd,
                custnm,
                itemcd,
                itemnm,
                cboPerson.EditValue.ToString(),
                finyn,
                cboDptcd.EditValue.ToString(),
                cboOrdsts.EditValue.ToString(),
                cboDoexdiv.EditValue.ToString(),
                cboOrdtype.EditValue.ToString(),
                txtPoregnum.Text,
                txtRemark2.Text,
                Config.CompanyCode,
                txtHullno.Text,
                0,
                0);

            try
            {
                ResultSet result = ExecuteProcedure(procInfo);

                if (workType.Equals("Q"))
                {
                    grdList.DataSource = result?[0];
                }
                else if (workType.Equals("DETAIL"))
                {
                    grdDetail.DataSource = result?[0];

                }
                else if (workType.Equals("REPORT"))
                {
                    dt = result?.Tables[0];
                }
                else if (workType.Equals("unp_628"))
                {
                    dt = result?.Tables[0];
                }

                return result?.IsSuccess ?? false;
            }
            catch (Exception ex)
            {
                ShowErrorMessageBox(ex);
                return false;
            }
        }

        private bool ExecuteSave(string workType)
        {
            if (!ValidateControls(grpMaster))
            {
                return false;
            }

            ParameterBuilder paramBuilder = new ParameterBuilder();

            if (!workType.Equals("D"))
            {
                DataTable source = CopyOfChangedData(grdDetail, false);

                if (workType.Equals("N"))
                {
                    if (source == null)
                    {
                        return false;
                    }
                    if ((source?.Rows?.Count ?? 0) == 0)
                    {
                        return false;
                    }
                }

                foreach (DataRow row in source.Rows)
                {
                    paramBuilder.Append(row, "row_status");
                    paramBuilder.Append(row, "ordseq");
                    paramBuilder.Append(row, "itemcd");
                    paramBuilder.Append(row, "itemnm");
                    paramBuilder.Append(row, "itemacnt");
                    paramBuilder.Append(row, "insiz");
                    paramBuilder.Append(row, "qty");
                    paramBuilder.Append(row, "qtyunit");
                    paramBuilder.Append(row, "unp");
                    paramBuilder.Append(row, "amt");
                    paramBuilder.Append(row, "taxamt");
                    paramBuilder.Append(row, "dlramt");
                    paramBuilder.Append(row, "wonamt");
                    paramBuilder.Append(row, "remark");
                    paramBuilder.Append(row, "finyn");
                    paramBuilder.Append(row, "lotnum");

                    paramBuilder.Append("dlvdt", row["dlvdt"].ToString().Left(10).Replace("-", ""));
                    paramBuilder.Append(row, "inordnum");
                    paramBuilder.Append(row, "inordseq");

                    paramBuilder.Append(row, "ordsts");
                    paramBuilder.Append(row, "sample");
                    paramBuilder.Append(row, "donate");
                    paramBuilder.Append(row, "ininspec");
                    paramBuilder.Append(row, "rcvcustcd");
                    paramBuilder.Append(row, "boxqty");
                    paramBuilder.Append(row, "ordsiz");
                    paramBuilder.Append(row, "remark2");

                    paramBuilder.Append(row, "thickness");
                    paramBuilder.Append(row, "width");
                    paramBuilder.Append(row, "len");
                    paramBuilder.Append(row, "totwgt");
                    paramBuilder.Append(row, "gubun");
                    paramBuilder.Append(row, "f_outside");
                    paramBuilder.Append(row, "classitem");
                    paramBuilder.Append(row, "acc");
                    paramBuilder.Append(row, "glpyn");
                    paramBuilder.Append(row, "thewgt");
                    paramBuilder.Append(row, "attdatnum");
                    paramBuilder.Append(row, "specialunp");
                    paramBuilder.Append(row, "specialamt");

                    paramBuilder.Append(row, "bnatur");
                    paramBuilder.Append(row, "hullno");
                }
            }

            var procInfo = new P_SA_A2000_S();

            procInfo.SetParamValues(
                workType,
                Config["orgdiv"],
                cboLocation1.EditValue.ToString(),
                txtOrdnum1.Text,
                txtPoregnum1.Text,
                txtProject.Text,
                cboOrdtype1.EditValue.ToString(),
                cboOrdsts1.EditValue.ToString(),
                cboOrddiv1.EditValue.ToString(),
                cboTaxdiv.EditValue.ToString(),
                ymdOrddt.yyyyMMdd,
                ymdDlvdt.yyyyMMdd,
                cboDptcd1.EditValue.ToString(),
                cboPerson1.EditValue.ToString(),
                cboAmtunit.EditValue.ToString(),
                txtPortnm.Text,
                txtPaymeth.Text,
                txtPrcterms.Text,
                bteCustcd1.Text,
                txtCustnm1.Text,
                txtRcvcustcd.Text,
                txtRcvcustnm.Text,
                numWonchgrat.Value,
                numUschgrat.Value,
                cboDoexdiv1.EditValue.ToString(),
                MemoRemark.Text,
                txtAttdatnum.Text,
                txtShipMethod.Text,
                txtDlvMethod.Text,
                chkUrgencyyn.EditValue.ToString(),
                txtHullno1.Text,

                // Detail
                paramBuilder.GetParameter("row_status"),
                paramBuilder.GetParameter("ordseq"),
                paramBuilder.GetParameter("itemcd"),
                paramBuilder.GetParameter("itemnm"),
                paramBuilder.GetParameter("itemacnt"),
                paramBuilder.GetParameter("insiz"),
                paramBuilder.GetParameter("qty"),
                paramBuilder.GetParameter("qtyunit"),
                paramBuilder.GetParameter("unp"),
                paramBuilder.GetParameter("amt"),
                paramBuilder.GetParameter("taxamt"),
                paramBuilder.GetParameter("dlramt"),
                paramBuilder.GetParameter("wonamt"),
                paramBuilder.GetParameter("remark"),
                paramBuilder.GetParameter("finyn"),
                paramBuilder.GetParameter("lotnum"),
                paramBuilder.GetParameter("inordnum"),
                paramBuilder.GetParameter("inordseq"),
                paramBuilder.GetParameter("dlvdt"),
                paramBuilder.GetParameter("ordsts"),
                paramBuilder.GetParameter("sample"),
                paramBuilder.GetParameter("donate"),
                paramBuilder.GetParameter("ininspec"),
                paramBuilder.GetParameter("rcvcustcd"),
                paramBuilder.GetParameter("boxqty"),
                paramBuilder.GetParameter("ordsiz"),
                paramBuilder.GetParameter("remark2"),
                Config.UserId,
                GetPcInfo(),
                this.FormId,
                Config.CompanyCode,
                paramBuilder.GetParameter("thickness"),
                paramBuilder.GetParameter("width"),
                paramBuilder.GetParameter("len"),
                paramBuilder.GetParameter("totwgt"),
                paramBuilder.GetParameter("gubun"),
                paramBuilder.GetParameter("f_outside"),
                paramBuilder.GetParameter("classitem"),
                paramBuilder.GetParameter("acc"),
                paramBuilder.GetParameter("glpyn"),
                paramBuilder.GetParameter("thewgt"),
                paramBuilder.GetParameter("attdatnum"),
                paramBuilder.GetParameter("specialunp"),
                paramBuilder.GetParameter("specialamt"),
                paramBuilder.GetParameter("bnatur"),
                paramBuilder.GetParameter("hullno"),
                0,
                0);

            try
            {
                ResultSet result = ExecuteProcedure(procInfo);

                bool isSuccess = result?.IsSuccess ?? false;

                if (isSuccess && !workType.Equals("D"))
                {
                    if (result.ReturnString.Contains("|"))  // 상세정보 모두 삭제 시 첨부파일도 삭제 되도록.  ex )  수주번호|첨부번호 
                    {
                        string[] splits = result.ReturnString?.Split('|') ?? new string[0];

                        AttachmentHelper.DeleteAttachments(splits.ElementAtOrDefault(1));
                        RetrieveHelper.SetValueToFindRow(gvwList, splits.ElementAtOrDefault(0));
                    }
                    else
                    {
                        RetrieveHelper.SetValueToFindRow(gvwList, result.ReturnString);
                    }
                }
                else if (workType.Equals("D"))
                {
                    AttachmentHelper.DeleteAttachments(result.ReturnString);
                }

                AttachmentHelper.Commit();

                return isSuccess;
            }
            catch (Exception ex)
            {
                ShowErrorMessageBox(ex);
                return false;
            }
        }

        //    GridView_CustomDrawCell
    }

    #region [Stored Procedure Class]
    internal sealed class P_SA_A2000_Q : ProcedureInfo
    {
        public P_SA_A2000_Q() : base(nameof(P_SA_A2000_Q)) { }

        protected override string[] GetParamKeys()
        {
            return new string[]
            {
                "@p_work_type",
                "@p_orgdiv",
                "@p_location",
                "@p_dtgb",
                "@p_frdt",
                "@p_todt",
                "@p_orddt",
                "@p_ordnum",
                "@p_custcd",
                "@p_custnm",
                "@p_itemcd",
                "@p_itemnm",
                "@p_person",
                "@p_finyn",
                "@p_dptcd",
                "@p_ordsts",
                "@p_doexdiv",
                "@p_ordtype",
                "@p_poregnum",
                "@p_remark2",
                "@p_company_code",
                "@p_hullno",
            };
        }

        public void SetParamValues(string @p_work_type, string @p_orgdiv,
            string @p_location, string @p_dtgb, string @p_frdt, string @p_todt, string @p_orddt,
            string @p_ordnum, string @p_custcd, string @p_custnm, string @p_itemcd,
            string @p_itemnm, string @p_person, string @p_finyn, string @p_dptcd,
            string @p_ordsts, string @p_doexdiv, string @p_ordtype, string @p_poregnum,
            string @p_remark2, string @p_company_code, string @p_hullno,
            int pageNumber, int pageSize)
        {
            SetParamValues(new object[] {
                @p_work_type,
                @p_orgdiv,
                @p_location,
                @p_dtgb,
                @p_frdt,
                @p_todt,
                @p_orddt,
                @p_ordnum,
                @p_custcd,
                @p_custnm,
                @p_itemcd,
                @p_itemnm,
                @p_person,
                @p_finyn,
                @p_dptcd,
                @p_ordsts,
                @p_doexdiv,
                @p_ordtype,
                @p_poregnum,
                @p_remark2,
                @p_company_code,
                @p_hullno,
            }, pageNumber, pageSize);
        }
    }

    internal sealed class P_SA_A2000_S : ProcedureInfo
    {
        public P_SA_A2000_S() : base(nameof(P_SA_A2000_S)) { }

        protected override string[] GetParamKeys()
        {
            return new string[]
            {
                "@p_work_type",
                "@p_orgdiv",
                "@p_location",
                "@p_ordnum",
                "@p_poregnum",
                "@p_project",
                "@p_ordtype",
                "@p_ordsts",
                "@p_orddiv",
                "@p_taxdiv",
                "@p_orddt",
                "@p_dlvdt",
                "@p_dptcd",
                "@p_person",
                "@p_amtunit",
                "@p_portnm",
                "@p_paymeth",
                "@p_prcterms",
                "@p_custcd",
                "@p_custnm",
                "@p_rcvcustcd",
                "@p_rcvcustnm",
                "@p_wonchgrat",
                "@p_uschgrat",
                "@p_doexdiv",
                "@p_remark",
                "@p_attdatnum",
                "@p_ship_method",
                "@p_dlv_method",
                "@p_urgencyyn",
                "@p_hullno",
                "@p_rowstatus_s",
                "@p_ordseq_s",
                "@p_itemcd_s",
                "@p_itemnm_s",
                "@p_itemacnt_s",
                "@p_insiz_s",
                "@p_qty_s",
                "@p_qtyunit_s",
                "@p_unp_s",
                "@p_amt_s",
                "@p_taxamt_s",
                "@p_dlramt_s",
                "@p_wonamt_s",
                "@p_remark_s",
                "@p_finyn_s",
                "@p_lotnum_s",
                "@p_inordnum_s",
                "@p_inordseq_s",
                "@p_dlvdt_s",
                "@p_ordsts_s",
                "@p_sample_s",
                "@p_donate_s",
                "@p_ininspec_s",
                "@p_rcvcustcd_s",
                "@p_boxqty_s",
                "@p_ordsiz_s",
                "@p_remark2_s",
                "@p_userid",
                "@p_pc",
                "@p_form_id",
                "@p_company_code",
                "@p_thickness_s",
                "@p_width_s",
                "@p_len_s",
                "@p_totwgt_s",
                "@p_gubun_s",
                "@p_f_outside_s",
                "@p_classitem_s",
                "@p_acc_s",
                "@p_glpyn_s",
                "@p_thewgt_s",
                "@p_attdatnum_s",
                "@p_specialunp_s",
                "@p_specialamt_s",
                "@p_bnatur_s",
                "@p_hullno_s",
            };
        }

        public void SetParamValues(string @p_work_type, string @p_orgdiv,
            string @p_location, string @p_ordnum, string @p_poregnum, string @p_project,
            string @p_ordtype, string @p_ordsts, string @p_orddiv, string @p_taxdiv, string @p_orddt,
            string @p_dlvdt, string @p_dptcd, string @p_person, string @p_amtunit,
            string @p_portnm, string @p_paymeth, string @p_prcterms, string @p_custcd,
            string @p_custnm, string @p_rcvcustcd, string @p_rcvcustnm, decimal @p_wonchgrat,
            decimal @p_uschgrat, string @p_doexdiv, string @p_remark, string @p_attdatnum,
            string @p_ship_method, string @p_dlv_method, string @p_urgencyyn, string @p_hullno,
            string @p_rowstatus_s,
            string @p_ordseq_s, string @p_itemcd_s, string @p_itemnm_s, string @p_itemacnt_s,
            string @p_insiz_s, string @p_qty_s, string @p_qtyunit_s, string @p_unp_s,
            string @p_amt_s, string @p_taxamt_s, string @p_dlramt_s, string @p_wonamt_s,
            string @p_remark_s, string @p_finyn_s, string @p_lotnum_s, string @p_inordnum_s,
            string @p_inordseq_s, string p_dlvdt_s, string @p_ordsts_s, string @p_sample_s,
            string @p_donate_s, string @p_ininspec_s, string @p_rcvcustcd_s, string @p_boxqty_s, string @p_ordsiz_s, string @p_remark2_s,
            string @p_userid, string @p_pc, string @p_form_id, string @p_company_code,
            string @p_thickness_s,
            string @p_width_s,
            string @p_len_s,
            string @p_totwgt_s,
            string @p_gubun_s,
            string @p_f_outside_s,
            string @p_classitem_s,
            string @p_acc_s,
            string @p_glpyn_s,
            string @p_thewgt_s,
            string @p_attdatnum_s,
            string @p_specialunp_s,
            string @p_specialamt_s,
            string @p_bnatur_s,
            string @p_hullno_s,
            int pageNumber, int pageSize)
        {
            SetParamValues(new object[] {
                @p_work_type,
                @p_orgdiv,
                @p_location,
                @p_ordnum,
                @p_poregnum,
                @p_project,
                @p_ordtype,
                @p_ordsts,
                @p_orddiv,
                @p_taxdiv,
                @p_orddt,
                @p_dlvdt,
                @p_dptcd,
                @p_person,
                @p_amtunit,
                @p_portnm,
                @p_paymeth,
                @p_prcterms,
                @p_custcd,
                @p_custnm,
                @p_rcvcustcd,
                @p_rcvcustnm,
                @p_wonchgrat,
                @p_uschgrat,
                @p_doexdiv,
                @p_remark,
                @p_attdatnum,
                @p_ship_method,
                @p_dlv_method,
                @p_urgencyyn,
                @p_hullno,
                @p_rowstatus_s,
                @p_ordseq_s,
                @p_itemcd_s,
                @p_itemnm_s,
                @p_itemacnt_s,
                @p_insiz_s,
                @p_qty_s,
                @p_qtyunit_s,
                @p_unp_s,
                @p_amt_s,
                @p_taxamt_s,
                @p_dlramt_s,
                @p_wonamt_s,
                @p_remark_s,
                @p_finyn_s,
                @p_lotnum_s,
                @p_inordnum_s,
                @p_inordseq_s,
                @p_dlvdt_s,
                @p_ordsts_s,
                @p_sample_s,
                @p_donate_s,
                @p_ininspec_s,
                @p_rcvcustcd_s,
                @p_boxqty_s,
                @p_ordsiz_s,
                @p_remark2_s,
                @p_userid,
                @p_pc,
                @p_form_id,
                @p_company_code,
                @p_thickness_s,
                @p_width_s,
                @p_len_s,
                @p_totwgt_s,
                @p_gubun_s,
                @p_f_outside_s,
                @p_classitem_s,
                @p_acc_s,
                @p_glpyn_s,
                @p_thewgt_s,
                @p_attdatnum_s,
                @p_specialunp_s,
                @p_specialamt_s,
                @p_bnatur_s,
                @p_hullno_s,
            }, pageNumber, pageSize);
        }
    }

    #endregion [End - Stored Procedure Class]