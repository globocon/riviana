// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//$(document).on('click', '#btnPrintPreCheckList', function () {
//    $('.order-checkbox').prop('checked', this.checked);
//});

function toggleCheckbox(selected) {
    document.querySelectorAll(`input[name='${selected.name}']`).forEach(cb => {
        if (cb !== selected) cb.checked = false;
    });
}

$(function () {

   

    // Function to replace form controls with text equivalents before rendering
    // Convert controls to plain text
    function convertControlsToText(originalContainer) {
        // Clone the container to avoid modifying the live DOM
        const clone = originalContainer.cloneNode(true);

        // Remove buttons and elements with class 'no-print'
        clone.querySelectorAll('button, .no-print').forEach(el => el.remove());

        // Handle each input, select, and textarea by referring to the original element
        const originalInputs = originalContainer.querySelectorAll('input:not([type=checkbox]):not([type=radio]), select');
        const cloneInputs = clone.querySelectorAll('input:not([type=checkbox]):not([type=radio]), select');

        cloneInputs.forEach((input, i) => {
            const original = originalInputs[i];
            const span = document.createElement('span');
            span.textContent = original?.value || '';
            span.style.display = 'inline-block';
            span.style.minWidth = original.offsetWidth + 'px';
            span.style.borderBottom = '1px dotted #999';
            input.replaceWith(span);
        });

        const originalSelects = originalContainer.querySelectorAll('select');
        const cloneSelects = clone.querySelectorAll('select');
        cloneSelects.forEach((select, i) => {
            const original = originalSelects[i];
            const selectedText = original?.options[original.selectedIndex]?.text || '';
            const span = document.createElement('span');
            span.textContent = selectedText;
            span.style.display = 'inline-block';
            span.style.minWidth = original.offsetWidth + 'px';
            span.style.borderBottom = '1px dotted #999';
            select.replaceWith(span);
        });

        // ---------- RADIO BUTTONS ----------
        // --- Replace RADIO BUTTON groups with their selected value (PASS/FAIL) ---
        // Replace radio groups with their selected value
        //const radioGroups = {};
        //// First, collect which radios are checked in the original
        //originalContainer.querySelectorAll('input[type="radio"]').forEach(r => {
        //    if (r.checked) {
        //        radioGroups[r.name] = r.value; // "PASS" or "FAIL"
        //    }
        //});

        //// Now, update the cloned DOM
        //const handled = new Set();

        //clone.querySelectorAll('input[type="radio"]').forEach(radio => {
        //    const group = radio.name;
        //    if (handled.has(group)) return;
        //    handled.add(group);

        //    // Get the selected value from original DOM (so you print PASS/FAIL)
        //    const selectedValue = (originalContainer.querySelector(`input[type="radio"][name="${group}"]:checked`) || {}).value || '';

        //    // Find the td (or fallback to parent)
        //    const td = radio.closest('td') || radio.parentElement;

        //    if (td) {
        //        // Remove all radio inputs in this group inside the clone
        //        td.querySelectorAll(`input[type="radio"][name="${group}"]`).forEach(r => r.remove());

        //        // Remove labels that reference those radios (by for=) anywhere in clone
        //        // (this helps when labels are not inside the same td)
        //        clone.querySelectorAll(`label`).forEach(lbl => {
        //            const forAttr = lbl.getAttribute('for');
        //            if (forAttr && td.querySelector(`#${forAttr}`) === null) {
        //                // If label belongs to a removed radio id, remove it.
        //                // (we removed the inputs already so checking td.querySelector('#id') returns null)
        //                // safer approach: check if original had label for that id and remove anyway:
        //                const targetInputInOriginal = originalContainer.querySelector(`#${forAttr}`);
        //                if (targetInputInOriginal && targetInputInOriginal.name === group) {
        //                    lbl.remove();
        //                }
        //            }
        //        });

        //        // Also remove any labels inside the td (covers most Bootstrap layouts)
        //        td.querySelectorAll('label, .form-check-label').forEach(l => l.remove());

        //        // Optionally remove stray text nodes like 'P' or 'F' that are direct children
        //        // (use with care — trims only short single-letter nodes)
        //        const childNodes = Array.from(td.childNodes);
        //        childNodes.forEach(n => {
        //            if (n.nodeType === Node.TEXT_NODE) {
        //                const txt = n.textContent.trim();
        //                if (txt.length > 0 && txt.length <= 3) { // tweak length threshold as needed
        //                    n.remove();
        //                }
        //            }
        //        });

        //        // Insert the selected text span
        //        const span = document.createElement('span');
        //        span.textContent = selectedValue;
        //        span.style.fontWeight = 'bold';
        //        span.style.marginLeft = '4px';
        //        td.appendChild(span);
        //    }
        //});


        //// ---------- CheckBox ----------
        //const originalChecks = originalContainer.querySelectorAll('input[type=checkbox]');
        //const cloneChecks = clone.querySelectorAll('input[type=checkbox]');
        //cloneChecks.forEach((check, i) => {
        //    const original = originalChecks[i];
        //    const span = document.createElement('span');
        //    span.textContent = original.checked ? 'Yes' : 'No';
        //    span.style.display = 'inline-block';
        //    span.style.borderBottom = '1px dotted #999';
        //    check.replaceWith(span);
        //});

        // ---------- CheckBox ----------
        const originalChecks = originalContainer.querySelectorAll('input[type=checkbox]');
        const cloneChecks = clone.querySelectorAll('input[type=checkbox]');
        clone.querySelectorAll('input[type=checkbox]').forEach((check, i) => {
            const original = originalChecks[i];

            // safety check
            if (!original) return;

            const td = check.closest('td') || check.parentElement;                        
            // Remove all related labels and checkboxes in this cell
            if (td) {
                const labels = td.querySelectorAll('label');
                labels.forEach(l => l.remove());

                const inputs = td.querySelectorAll('input[type="checkbox"]');
                inputs.forEach(inp => inp.remove());
            }

            // Define opposite values map
            const opposites = {
                'PASS': 'FAIL',
                'FAIL': 'PASS',
                'YES': 'NO',
                'NO': 'YES'
            };

            // Only add span for the checked value (or its opposite)
            const span = document.createElement('div');
            span.textContent = original.checked ? original.value : (opposites[original.value] || '');
            span.style.whiteSpace = 'pre-wrap';
            span.style.border = '1px dashed #ccc';
            span.style.padding = '4px';
            span.style.display = 'inline-block';

            if (td) td.appendChild(span);
        });


        const originalTextareas = originalContainer.querySelectorAll('textarea');
        const cloneTextareas = clone.querySelectorAll('textarea');
        cloneTextareas.forEach((textarea, i) => {
            const original = originalTextareas[i];
            const div = document.createElement('div');
            div.textContent = original?.value || '';
            div.style.whiteSpace = 'pre-wrap';
            div.style.border = '1px dashed #ccc';
            div.style.padding = '4px';
            textarea.replaceWith(div);
        });

        // Log the resulting HTML to console as readable text
        //console.log('----- Converted HTML for print -----');
        //console.log(new XMLSerializer().serializeToString(clone));
        return clone;
    }

    // Update progress bar
    function updateProgress(percent) {
        const progressContainer = document.getElementById("progressContainer");
        const progressBar = document.getElementById("progressBar");
        progressContainer.style.display = "block";
        progressBar.style.width = percent + "%";
        progressBar.textContent = percent + "%";
    }



    document.getElementById("btnPrintPreCheckList").addEventListener("click", async () => {
        const { jsPDF } = window.jspdf;
        const pdf = new jsPDF('l', 'mm', 'a4');

        const pages = [document.getElementById("page1"), document.getElementById("page2")];
        const totalPages = pages.length;

        updateProgress(0);

        for (let i = 0; i < totalPages; i++) {
            const element = pages[i];

            // Attach hidden clone to DOM
            const cleanElement = convertControlsToText(element);
            const hiddenContainer = document.createElement('div');
            hiddenContainer.style.position = 'fixed';
            hiddenContainer.style.left = '-9999px';
            hiddenContainer.appendChild(cleanElement);
            document.body.appendChild(hiddenContainer);

            const canvas = await html2canvas(cleanElement, { scale: 2, useCORS: true });
            document.body.removeChild(hiddenContainer);

            const imgData = canvas.toDataURL("image/png");
            const pageWidth = 297;
            const pageHeight = 210;
            const imgWidth = pageWidth - 20;
            const imgHeight = canvas.height * imgWidth / canvas.width;

            if (i > 0) pdf.addPage();
            pdf.addImage(imgData, 'PNG', 10, 10, imgWidth, imgHeight);

            // Update progress bar (smooth)
            updateProgress(Math.round(((i + 1) / totalPages) * 100));
        }

        pdf.save("Landscape_MultiPage.pdf");

        // Hide progress bar after save
        setTimeout(() => {
            document.getElementById("progressContainer").style.display = "none";
        }, 1000);
    });



    //$('#btnPrintPreCheckList').on('click', function (e) {
    //    // Handle Print Orders button click
    //    e.preventDefault();
    //    var orderDate = $('#OrderDate').val();
    //    if (!orderDate) {
    //        round_warning_noti('Please select an order date.');
    //        return;
    //    }
    //    // Open the PDF in a new tab
    //    window.open(`/ConfirmOrder?handler=PrintReport&selectedOrderDate=${encodeURIComponent(orderDate)}`, '_blank');
    //});
});